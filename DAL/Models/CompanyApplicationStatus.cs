using DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CompanyApplicationStatus : GenericModel
    {

        public ICollection<Application> Applications { get; set; }

    }
}
