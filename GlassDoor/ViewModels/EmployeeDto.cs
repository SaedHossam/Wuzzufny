using DAL.Models;
using glassDoor.ViewModels;
using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class EmployeeDto 
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public DateTime BirthDate { get; set; }

        public Enums.Gender Gender { get; set; }
        public Enums.MilitaryStatus MilitaryStatus { get; set; } //************

        public string CityName { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public bool IsWillingToRelocate { get; set; }
        public string MobileNumber { get; set; }
        public string AlternativeMobileNumber { get; set; }
        public int? CareerLevelId { get; set; }
        public string CareerLevelName { get; set; }
        public ICollection<JobTypeDto> JobTypesName { get; set; }
        public ICollection<JobCategoryDto> PreferredJobCategoriesName { get; set; }
        public int MinimumSalary { get; set; }
        public int ExperienceYears { get; set; }
        public ICollection<SkillsDto> SkillsNames { get; set; }
        public ICollection<UserLanguageDto> UserLanguagesNames { get; set; }
        public ICollection<EmployeeLinksDto> EmployeeLinksNames { get; set; }
        public string CV { get; set; }
        public string Photo { get; set; }
        public string Summary { get; set; }
       // public int? EducationLevelId { get; set; }
        public string EducationLevelName { get; set; }
        //public int? NationalityId { get; set; }
        public string NationalityName { get; set; }

        //public IEnumerable<JobViewModel> JobTitle { get; set; }
        public string UserFirstName { get; set; }  //application user
        public string UserLastName { get; set; }  //application user

        public string Email { get; set; }
        //public ICollection<Application> Applications { get; set; }
    }
}
