using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.Entities;
using DreamMaker.UI.ViewModels;
using DreamMaker.Domain.ModelMapper;

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
                throw new NotImplementedException();
            }
        }

        public IEnumerable<RoomViewModel> LatestRooms(int offset, int limit)
        {
            var dbModels = _appContext.Rooms.OrderByDescending(r => r.CreateTime).Skip(offset).Take(limit);
            var viewModels = dbModels.Select(m => _modelMapper.GetRoomViewModelFromEntity(m));
            return viewModels;
        }
    }
}
