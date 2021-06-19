using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanyLocationDto
    {
        public int companyId { get; set; }
        public int cityId { get; set; }
        public City city { get; set; }

    }
}
