using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class CompanyLocation
    {
        public int companyId { get; set; }
        public int cityId { get; set; }
        public Company companies { get; set; }
        public City cities { get; set; }
    }
}
