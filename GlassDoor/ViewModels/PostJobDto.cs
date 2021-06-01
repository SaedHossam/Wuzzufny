using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class PostJobDto
    {
        [Required]
        public string Title { get; set; }
        public string EmploymentType { get; set; }
        public int? NumberOfVacancies { get; set; }
        public string Location { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public JobDetails JobDetails { get; set; }
        public ICollection<Skill> Skills { get; set; }

    }
}

