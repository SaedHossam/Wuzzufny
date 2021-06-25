using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class JobStatisticsViewModel
    {
        public int TotalApplications { get; set; }
        public int ViewedApplications { get; set; }
        public int InConsiderationApplications { get; set; }
        public int RejectedApplications { get; set; }
        public int HiredApplications { get; set; }
        public int TotalClicks { get; set; }

    }
}
