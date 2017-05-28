using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamMaker.UI.ViewModels
{
    public class FundingProjectViewModel
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public UserViewModel Creator { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
