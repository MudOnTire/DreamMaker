using System.ComponentModel.DataAnnotations;
using DreamMaker.Utility.Constants;

namespace DreamMaker.UI.InputModels
{
    public class CreateFundingProjectInputModel
    {
        [Required]
        [Display(Name = "梦想")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "类型")]
        public string ProjectType { get; set; }

        [Required]
        [Display(Name = "描述")]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        public string ProjectDescription { get; set; }
    }
}