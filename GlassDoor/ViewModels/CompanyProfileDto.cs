using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanyProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string AboutUs { get; set; }
        public DateTime? YearFounded { get; set; }
        public string Phone { get; set; }
        public CompanyType CompanyType { get; set; }
        public int? CompanyTypeId { get; set; }
        public CompanyIndustry CompanyIndustry { get; set; }
        public int? CompanyIndustryId { get; set; }
        public CompanySize CompanySize { get; set; }
        public int? CompanySizeId { get; set; }
        public ICollection<CityDto> Locations { get; set; }
        public ICollection<CompanyLinksDto> CompanyLinks { get; set; }
    }
}
