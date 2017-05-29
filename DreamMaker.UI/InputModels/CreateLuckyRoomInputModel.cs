using System.ComponentModel.DataAnnotations;

namespace DreamMaker.UI.InputModels
{
    public class CreateLuckyRoomInputModel
    {
        [Required]
        [Display(Name = "房间昵称")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string RoomName { get; set; }

        [Required]
        [Display(Name = "最大人数")]
        public int MaxMemberCount { get; set; }
    }
}