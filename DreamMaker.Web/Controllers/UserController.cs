using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamMaker.Web.Controllers
{
    public class UserController : Controller
    {
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
            return View();
        }
    }
}