using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models.Interfaces;

namespace DAL.Models
{
    public class Job: IAuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EmploymentType { get; set; }
        public int? NumberOfVacancies { get; set; }
        public string Location { get; set; }

        public int TotalApplications => Applications?.Count ?? 0;
        public int TotalClicks { get; set; }
        public int? AcceptedApplications => Applications?.Count(a => a.Status.Equals("Accepted"));
        public int? RejectedApplications => Applications?.Count(a => a.Status.Equals("Rejected"));
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
