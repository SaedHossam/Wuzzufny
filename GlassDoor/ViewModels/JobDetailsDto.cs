using DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class JobDetailsDto
    {
        public int Id { get; set; }
        public int? ExperienceNeededMin { get; set; }
        public int? ExperienceNeededMax { get; set; }
        public int CareerLevelId { get; set; }
        public CareerLevel CareerLevel { get; set; }
        public int EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public int? SalaryMin { get; set; }
        public int? SalaryMax { get; set; }
       // public int SalaryCurrencyId { get; set; }
        public Currency SalaryCurrency { get; set; }
        //public int SalaryRateId { get; set; }
        public SalaryRate SalaryRate { get; set; }

       // public int JobCategoryId { get; set; }
        public JobCategory Category { get; set; }

        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }


        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}

