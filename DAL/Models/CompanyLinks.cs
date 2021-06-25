using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CompanyLinks : SocialLinks
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
