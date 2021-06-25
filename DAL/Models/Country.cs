using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<Job> Jobs { get; set; }

        public ICollection<Employee> EmployeesNationality { get; set; }
        public ICollection<Employee> EmployeesLocation { get; set; }
    }
}
