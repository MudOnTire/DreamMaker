using DreamMaker.Domain.Abstract;
using DreamMaker.UI.InputModels;
using DreamMaker.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DreamMaker.Web.Controllers
{
    public class LuckyCenterController : Controller
    {
        private IUserRepository _userRepository;
        private IRoomRepository _roomRepository;
        private IUserWalletRepository _userWalletRepository;

        public LuckyCenterController(IUserRepository userRepository, IRoomRepository roomRepository, IUserWalletRepository userWalletRepository)
        {
            _userRepository = userRepository;
            _roomRepository = roomRepository;
            _userWalletRepository = userWalletRepository;
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = _userRepository.GetCurrentUser();
                if (currentUser.Room != null)
                {
                    return RedirectToAction("Detail", new { roomId = currentUser.Room.RoomId });
                }
            }
            return View();
        }
        
        /// <summary>
        /// 创建房间页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 创建房间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult Create(CreateLuckyRoomInputModel model)
        {
            var newRoomId = _roomRepository.Create(model);
            return RedirectToAction("Detail", new { roomId = newRoomId });
        }

        /// <summary>
        /// 房间详情
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public ActionResult Detail(long roomId)
        {
            var vm = _roomRepository.GetViewModel(roomId);
            return View(vm);
        }

        /// <summary>
        /// 房间列表
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public ActionResult RoomList(int offset = 0, int limit=20)
        {
            var model = _roomRepository.LatestRooms(offset, limit);
            return PartialView(model);
        }

        /// <summary>
        /// 登录用户加入房间
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult Join(long roomId)
        {
            UserWalletViewModel wallet = _userWalletRepository.GetCurrentUserWalletViewModel();
            if (wallet.CurrentBalance < 1)
            {
                TempData["Warning"] = "您的余额不足，请先充值";
                return RedirectToAction("MyWallet", "User");
            }
            if (_userWalletRepository.Expense(1))
            {
                bool result = _roomRepository.JoinRoom(roomId);
                if (result)
                {
                    return RedirectToAction("Detail", new { roomId = roomId });
                }
                else
                {
                    return new HttpNotFoundResult();
                }
            }
            else
            {
                TempData["Warning"] = "扣款失败";
                return RedirectToAction("MyWallet", "User");
            }
        }
        
        /// <summary>
        /// 登录用户当前房间
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Leave()
        {
            bool result = _roomRepository.LeaveRoom();
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}