using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.Entities;
using DreamMaker.UI.ViewModels;

namespace DreamMaker.Domain.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private ApplicationDbContext _appContext = new ApplicationDbContext();

        public IEnumerable<Room> Rooms
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<RoomViewModel> LatestRooms(int offset, int limit)
        {
            return null;
        }
    }
}
