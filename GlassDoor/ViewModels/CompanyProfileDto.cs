using System;
using System.Collections.Generic;

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
        public int CompanyTypeId { get; set; }
        public CompanyTypeDto CompanyType { get; set; }
        public int CompanyIndustryId { get; set; }
        public CompanyIndustryDto CompanyIndustry { get; set; }
        public int CompanySizeId { get; set; }
        public CompanySizeDto CompanySize { get; set; }
        public ICollection<CompanyLocationDto> Locations { get; set; }
        public int? requestStatusId { get; set; }
        public string CompanyType1 { get; set; }
        public string CompanyIndustry1 { get; set; }
        public string CompanySize1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<CityDto> Locations1 { get; set; }
        public ICollection<CompanyLinksDto> CompanyLinks { get; set; }
    }
}
