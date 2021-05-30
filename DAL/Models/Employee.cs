using System.Collections.Generic;

namespace DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
