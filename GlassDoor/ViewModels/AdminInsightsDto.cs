using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class AdminInsightsDto
    {
        public int OpenJobs { get; set; }
        public int CompaniesCount { get; set; }
        public ICollection<JobsByDate> TotalJobsByDate { get; set; }
        public ICollection<JobsByType> OpenJobsByType { get; set; }
        public ICollection<JobsByCountry> OpenJobsByCountry { get; set; }
        //public int JobsByCity { get; set; }
        public ICollection<JobsByJobCategory> OpenJobsByJobCategory { get; set; }
    }

    public class JobsByDate
    {
        public string Date { get; set; }
        public int Count { get; set; }
    }

    public class JobsByType
    {
        public string Type { get; set; }
        public int Count { get; set; }
    }

    public class JobsByCountry
    {
        public string Country { get; set; }
        public int Count { get; set; }
    }

    public class JobsByJobCategory
    {
        public string Category { get; set; }
        public int Count { get; set; }
    }
}
