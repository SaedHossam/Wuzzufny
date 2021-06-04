using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlassDoor.ViewModels.shared;

namespace GlassDoor.ViewModels
{
    public class CompanyIndustryDto : GenericDto
    {
    }

    public class CompanyIndustryCreateDto
    {
        public string Name { get; set; }
    }
}
