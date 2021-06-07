using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string AboutUs { get; set; }
        public DateTime? YearFounded { get; set; }
        public string Phone { get; set; }
        public int? CompanyTypeId { get; set; }
        public CompanyType CompanyType { get; set; }
        public int? CompanyIndustryId { get; set; }
        public CompanyIndustry CompanyIndustry { get; set; }
        public int? CompanySizeId { get; set; }
        public CompanySize CompanySize { get; set; }
        public int RequestStatusId { get; set; }
        public CompanyRequestStatus RequestStatus { get; set; }
        public ICollection<City> Locations { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<CompanyManager> CompanyManagers { get; set; }
        public ICollection<CompanyLinks> CompanyLinks { get; set; }
    }
}
