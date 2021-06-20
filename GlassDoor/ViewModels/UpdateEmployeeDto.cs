using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class UpdateEmployeeDto
    {
        //public int Id { get; set; }
        //comment CV and Photo because they are in deffrerent Dto 
        //public string CV { get; set; }
        //public string Photo { get; set; }

        // Moving CareerLevelId , MinimumSalary to PreferedJobCatDto
        // Moving EducationLevelId , ExperienceYears to EducationAndExpDto
        public string Summary { get; set; }
        public string MobileNumber { get; set; }
        public string AlternativeMobileNumber { get; set; }
        public bool IsWillingToRelocate { get; set; }
        public int CountryId { get; set; }
        public int CityId{ get; set; }
        public int? NationalityId { get; set; }
        public DateTime BirthDate { get; set; }
        public Enums.Gender Gender { get; set; }
        public Enums.MilitaryStatus MilitaryStatus { get; set; }

        /*UPDATE*/
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

    }
}
