using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CompanyManager
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }

        public ApplicationUser User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
