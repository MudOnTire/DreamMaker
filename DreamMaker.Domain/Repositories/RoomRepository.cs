using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.Entities;

namespace DreamMaker.Domain.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private ApplicationDbContext _appContext = new ApplicationDbContext();

        IEnumerable<Room> IRoomRepository.Rooms
        {
            get { return _appContext.Rooms; }
        }
    }
}
