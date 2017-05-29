using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamMaker.UI.ViewModels
{
     public class RoomViewModel
    {
        public long RoomId { get; set; }

        public string RoomName { get; set; }

        public int MaxMemberCount { get; set; }

        public int CreatorId { get; set; }

        public IEnumerable<UserViewModel> Members { get; set; }
    }
}
