using DreamMaker.Domain.Entities;
using DreamMaker.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamMaker.Domain.ModelMapper
{
    public class ModelMapper:IModelMapper
    {
        private ApplicationDbContext _appContext = new ApplicationDbContext();

        public UserViewModel GetUserViewModeFromEntity(ApplicationUser user)
        {
            return new UserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName
            };
        }

        public RoomViewModel GetRoomViewModelFromEntity(Room room)
        {
            var creator = _appContext.Users.FirstOrDefault(u => u.Id == room.CreatorId);
            if (creator == null)
            {
                throw new Exception(string.Format("room {0} has no creator", room.RoomId));
            }
            List<UserViewModel> members = new List<UserViewModel>();
            foreach(var member in room.Members)
            {
                members.Add(this.GetUserViewModeFromEntity(member));
            }
            return new RoomViewModel
            {
                RoomId = room.RoomId,
                RoomName = room.RoomName,
                MaxMemberCount = room.MaxMemberCount,
                Creator = this.GetUserViewModeFromEntity(creator),
                CreateTime = room.CreateTime,
                Members = members
            };
        }

        public FundingProjectViewModel GetFundingProjectViewModelFromEntity(FundingProject project)
        {
            var creator = _appContext.Users.FirstOrDefault(u => u.Id == project.CreatorId);
            if (creator == null)
            {
                throw new Exception(string.Format("project {0} has no creator", project.ProjectId));
            }
            return new FundingProjectViewModel
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription,
                Creator = this.GetUserViewModeFromEntity(creator),
                CreateTime = project.CreateTime
            };
        }
    }
}
