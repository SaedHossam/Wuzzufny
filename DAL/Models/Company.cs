using System.Collections.Generic;

namespace DAL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Locations { get; set; }
        public string Logo { get; set; }

        public ICollection<Job> Jobs { get; set; }
        public ICollection<CompanyManager> CompanyManagers { get; set; }
    }
}
