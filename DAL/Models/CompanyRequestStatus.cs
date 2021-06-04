using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Shared;

namespace DAL.Models
{
    public class CompanyRequestStatus : GenericModel
    {
        public ICollection<Company> Companies { get; set; }
    }
}
