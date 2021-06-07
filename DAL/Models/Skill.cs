using System.Collections.Generic;

namespace DAL.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<JobSkill> Jobs { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
