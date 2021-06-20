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
        //public int CareerLevelId { get; set; }
        //public CareerLevel CareerLevel { get; set; }

        public string CareerLevelName { get; set; }
        //public int EducationLevelId { get; set; }
        //public EducationLevel EducationLevel { get; set; }
        public string EducationLevelName { get; set; }
        public int? SalaryMin { get; set; }
        public int? SalaryMax { get; set; }
       // public int SalaryCurrencyId { get; set; }
        public string SalaryCurrencyName { get; set; }
        public string SalaryCurrencyCode { get; set; }
        public string SalaryCurrencySymbol { get; set; }
        //public int SalaryRateId { get; set; }
        public string SalaryRate { get; set; }

       // public int JobCategoryId { get; set; }
        public string Category { get; set; }

        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }

        public string CompanyName { get; set; }
        public DateTime? YearFounded { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public int JobId { get; set; }
        public int Vacancies { get; set; }

        public IEnumerable<SkillsMatching> SkillsNames { get; set; }
        public DateTime CreatedDate { get; set; }
        public string JobType { get; set; }
        public string JobTitle { get; set; }
        public string JobCountry { get; set; }
        public string JobCity { get; set; }
        public bool Applied { get; set; }
    }
}

