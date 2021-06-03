using DAL.Core;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace glassDoor.ViewModels
{
    public class JobViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public int? NumberOfVacancies { get; set; }
        public string Location { get; set; }

        //public int TotalApplications => Applications.Count;
        public int TotalClicks { get; set; }
        //public int AcceptedApplications => Applications.Count(a => a.Status.Equals("Accepted"));
        //public int RejectedApplications => Applications.Count(a => a.Status.Equals("Rejected"));
        public int ViewedApplications { get; set; }
        public int WithdrawnApplications { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Company Company { get; set; }
        public JobDetails JobDetails { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
