using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Entities;
using DreamMaker.UI.ViewModels;
using DreamMaker.UI.InputModels;

namespace DreamMaker.Domain.Abstract
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Rooms { get; }

        RoomViewModel GetViewModel(long roomId);

        IEnumerable<RoomViewModel> LatestRooms(int offset, int limit);

        long Create(CreateLuckyRoomInputModel model);

        bool JoinRoom(long roomId);
    }
}
