using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanyProfileDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string AboutUs { get; set; }
        public DateTime? YearFounded { get; set; }
        public string Phone { get; set; }
        public CompanyTypeDto CompanyType { get; set; }
        public CompanyIndustryDto CompanyIndustry { get; set; }
        public CompanySizeDto CompanySize { get; set; }
        public ICollection<CityDto> Locations { get; set; }
        public int? requestStatusId { get; set; }
        public ICollection<CompanyLinksDto> CompanyLinks { get; set; }
    }
}
