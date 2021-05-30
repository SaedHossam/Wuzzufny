using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace glassDoor.ViewModels
{
    public class JobDetailsViewModel
    {
        public int Id { get; set; }
        public int? ExperienceNedded { get; set; }
        public string CarrerLevel { get; set; }
        public string EducationLevel { get; set; }
        public int Salary { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }
        public string Status { get; set; }

        public int JobId { get; set; }

        public Job Job { get; set; }

    }
}
