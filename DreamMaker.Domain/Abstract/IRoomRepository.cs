using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Entities;

namespace DreamMaker.Domain.Abstract
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Rooms { get; } 
    }
}
