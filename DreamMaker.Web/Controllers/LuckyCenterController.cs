using DreamMaker.Domain.Abstract;
using DreamMaker.UI.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamMaker.Web.Controllers
{
    public class LuckyCenterController : Controller
    {
        private IRoomRepository _roomRepository;

        public LuckyCenterController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public ActionResult Index()
        {
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
    }
}