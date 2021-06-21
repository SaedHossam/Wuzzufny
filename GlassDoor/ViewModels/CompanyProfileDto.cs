using System;
using System.Collections.Generic;

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
        public string CompanyType { get; set; }
        public string CompanyIndustry { get; set; }
        public string CompanySize { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<CityDto> Locations { get; set; }
        public ICollection<CompanyLinksDto> CompanyLinks { get; set; }
    }
}
