using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class SeedAngular
    {
        public ICollection<JobType> jobTypes  { get; set; }
        public ICollection<JobCategory> jobCategories { get; set; }
        public ICollection<Country> countries { get; set; }
        public ICollection<City> cities { get; set; }
        public ICollection<CareerLevel> careerLevels { get; set; }
        public ICollection<Currency> Currencies { get; set; }
        public ICollection<SalaryRate> salaryRates { get; set; }
        public ICollection<Skill> Skills { get; set; }
    




    }
}
