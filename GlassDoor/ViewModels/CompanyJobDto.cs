using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanyJobDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public int JobTypeId { get; set; }
        public int? NumberOfVacancies { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public bool? IsOpen { get; set; }
        public CompanyJobDetailsDto JobDetails { get; set; }
        public ICollection<SkillsDto> Skills { get; set; }
    }
}
