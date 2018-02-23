using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamMaker.Utility.Constants
{
    public enum ProjectType
    {
        [Description("其他")]
        Other,
        [Description("医疗")]
        HealthCare,
        [Description("教育")]
        Education,
        [Description("创业")]
        StartUpBusiness
    }
}
