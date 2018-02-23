using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Utility.Constants;

namespace DreamMaker.Domain.Entities
{
    public class FundingProject
    {
        [Key]
        public int ProjectId { get; set; }

        public ProjectType ProjectType { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public string CreatorId { get; set; }

        public DateTime CreateTime { get; set;}
    }
}
