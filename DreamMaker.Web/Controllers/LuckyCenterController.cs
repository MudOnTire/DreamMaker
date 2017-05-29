using DreamMaker.Domain.Abstract;
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

        public ActionResult RoomList(int offset = 0, int limit=20)
        {
            var model = _roomRepository.LatestRooms(offset, limit);
            return PartialView(model);
        }
    }
}