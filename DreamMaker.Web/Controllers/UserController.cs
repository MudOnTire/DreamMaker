using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.ModelMapper;
using DreamMaker.Domain.Repositories;

namespace DreamMaker.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserWalletRepository _userWalletRepository;
        private IModelMapper _modelMapper;

        public UserController(IUserWalletRepository userWalletRepository, IModelMapper modelMapper)
        {
            _userWalletRepository = userWalletRepository;
            _modelMapper = modelMapper;
        }

        /// <summary>
        /// 登录用户自己的管理界面
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyWallet()
        {
            var dbModel = _userWalletRepository.GetCurrentUserWallet();
            var vm = _modelMapper.GetUserWalletViewModelFromEntity(dbModel);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RechargeMyWallet(decimal amount)
        {
            bool result = _userWalletRepository.Recharge(amount);
            if (result)
            {
                return Json(new {amount = amount}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {amount = 0}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}