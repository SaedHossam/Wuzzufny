using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        
        public DateTime BirthDate { get; set; }

        public Enums.Gender Gender { get; set; }
        public Enums.MilitaryStatus MilitaryStatus { get; set; }

        public City City { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public bool IsWillingToRelocate { get; set; }
        public string MobileNumber { get; set; }
        public string AlternativeMobileNumber { get; set; }
        public int? CareerLevelId { get; set; }
        public CareerLevel CareerLevel { get; set; }
        public ICollection<JobType> JobTypes { get; set; }
        public ICollection<JobCategory> PreferredJobCategories { get; set; }
        public int MinimumSalary { get; set; }
        public int ExperienceYears { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<UserLanguage> UserLanguages { get; set; }
        public ICollection<EmployeeLinks> EmployeeLinks { get; set; }
        public string CV { get; set; }
        public string Photo { get; set; }
        public string Summary { get; set; }
        public int? EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public int? NationalityId { get; set; }
        public Country Nationality { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
