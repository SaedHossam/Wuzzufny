using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanyEmployeeDto
    {
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string MilitaryStatus { get; set; }
        public CityDto City { get; set; }
        public CountryDto Country { get; set; }
        public bool IsWillingToRelocate { get; set; }
        public string MobileNumber { get; set; }
        public string AlternativeMobileNumber { get; set; }
        public CareerLevelDto CareerLevel{ get; set; }
        public int MinimumSalary { get; set; }
        public int ExperienceYears { get; set; }
        public ICollection<SkillsDto> Skills { get; set; }
        public ICollection<UserLanguageDto> UserLanguages { get; set; }
        public ICollection<EmployeeLinksDto> EmployeeLinks { get; set; }
        public string CV { get; set; }
        public string Photo { get; set; }
        public string Summary { get; set; }
        public EducationLevelDto EducationLevel{ get; set; }
        public int? NationalityId { get; set; }
        
    }
}
