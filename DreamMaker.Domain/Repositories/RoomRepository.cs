using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.Entities;
using DreamMaker.UI.ViewModels;
using DreamMaker.Domain.ModelMapper;
using DreamMaker.UI.InputModels;
using System.Web;
using DreamMaker.Domain.DBContext;
using Microsoft.AspNet.Identity;

namespace DreamMaker.Domain.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private ApplicationDbContext _appContext = new ApplicationDbContext();

        private IModelMapper _modelMapper;

        public RoomRepository(IModelMapper modelMapper)
        {
            _modelMapper = modelMapper;
        }

        public IEnumerable<Room> Rooms
        {
            get
            {
                return _appContext.Rooms;
            }
        }

        /// <summary>
        /// 获取房间的ViewModel
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public RoomViewModel GetViewModel(long roomId)
        {
            var dbModel = Rooms.FirstOrDefault(r => r.RoomId == roomId);
            if (dbModel == null)
            {
                throw new Exception(string.Format("房间{0}没有找到", roomId));
            }
            return _modelMapper.GetRoomViewModelFromEntity(dbModel);
        }

        /// <summary>
        /// 创建房间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Create(CreateLuckyRoomInputModel model)
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var currentUser = _appContext.Users.FirstOrDefault(u => u.Id == currentUserId);
            var newRoom = new Room
            {
                RoomName = model.RoomName,
                MaxMemberCount = model.MaxMemberCount,
                CreatorId = currentUserId,
                CreateTime = DateTime.Now,
                Members = new List<ApplicationUser>()
            };
            newRoom.Members.Add(currentUser);
            var addedRoom = _appContext.Rooms.Add(newRoom);
            _appContext.SaveChanges();
            return addedRoom.RoomId;
        }

        /// <summary>
        /// 获取最新的房间列表
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IEnumerable<RoomViewModel> LatestRooms(int offset, int limit)
        {
            var dbModels = _appContext.Rooms.OrderByDescending(r => r.CreateTime).Skip(offset).Take(limit);
            List<RoomViewModel> viewModels = new List<RoomViewModel>();
            foreach (var dbModel in dbModels)
            {
                viewModels.Add(_modelMapper.GetRoomViewModelFromEntity(dbModel));
            }
            return viewModels;
        }

        /// <summary>
        /// 登录用户加入房间
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public bool JoinRoom(long roomId)
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var currentUser = _appContext.Users.FirstOrDefault(u => u.Id == currentUserId);
            var room = _appContext.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            if (room == null)
            {
                throw new Exception(string.Format("没有找到房间{0}", roomId));
            }
            room.Members.Add(currentUser);
            _appContext.SaveChanges();
            return true;
        }
    }
}
