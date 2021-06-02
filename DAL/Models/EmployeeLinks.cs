using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EmployeeLinks : SocialLinks
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }   
}
