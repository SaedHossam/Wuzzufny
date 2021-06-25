using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CompanyManager CompanyManager { get; set; }

        public Employee Employee { get; set; }
    }
}
