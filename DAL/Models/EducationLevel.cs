using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EducationLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<JobDetails> JobDetails { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
