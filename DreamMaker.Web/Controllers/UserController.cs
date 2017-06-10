using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.Repositories;

namespace DreamMaker.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserWalletRepository _userWalletRepository;

        public UserController(IUserWalletRepository userWalletRepository)
        {
            _userWalletRepository = userWalletRepository;
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
            var model = _userWalletRepository.GetCurrentUserWalletViewModel();
            return View(model);
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