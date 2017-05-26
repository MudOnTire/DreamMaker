using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.Concrete;
using DreamMaker.Domain.Entities;

namespace DreamMaker.Domain.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private EfDbContext _context = new EfDbContext();

        IEnumerable<Room> IRoomRepository.Rooms
        {
            get { return _context.Rooms; }
        }
    }
}
