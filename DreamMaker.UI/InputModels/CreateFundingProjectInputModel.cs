using System.ComponentModel.DataAnnotations;

namespace DreamMaker.UI.InputModels
{
    public class CreateFundingProjectInputModel
    {
        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string ProjectDescription { get; set; }
    }
}