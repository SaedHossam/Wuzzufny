using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanyApplicationDto
    {
        public int Id { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Status { get; set; }
        public CompanyEmployeeDto Employee { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeCity { get; set; }
        public string EmployeeCountry { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        public int EmployeeExperience { get; set; }
        public string EmployeeEducation { get; set; }
        public string EmployeePhoto { get; set; }
    }
      
    
}
