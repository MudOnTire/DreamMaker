using DreamMaker.Domain.Entities;
using DreamMaker.UI.ViewModels;

namespace DreamMaker.Domain.ModelMapper
{
    public interface IModelMapper
    {
        UserViewModel GetUserViewModeFromEntity(ApplicationUser user);

        RoomViewModel GetRoomViewModelFromEntity(Room room);

        FundingProjectViewModel GetFundingProjectViewModelFromEntity(FundingProject project);
    }
}
