using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class EmployeeDto
    {
        public string UserId { get; set; }

        public DateTime BirthDate { get; set; }

        public Enums.Gender Gender { get; set; }
        public Enums.MilitaryStatus MilitaryStatus { get; set; }

        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public bool IsWillingToRelocate { get; set; }
        public string MobileNumber { get; set; }
        public string AlternativeMobileNumber { get; set; }
        public int? CareerLevelId { get; set; }
        public int MinimumSalary { get; set; }
        public int ExperienceYears { get; set; }
        public ICollection<SkillsDto> Skills { get; set; }
        public ICollection<UserLanguageDto> UserLanguages { get; set; }
        public ICollection<EmployeeLinksDto> EmployeeLinks { get; set; }
        public string CV { get; set; }
        public string Photo { get; set; }
        public string Summary { get; set; }
        public int? EducationLevelId { get; set; }
        public int? NationalityId { get; set; }
        
    }
}
