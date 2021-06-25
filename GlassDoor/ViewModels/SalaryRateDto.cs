using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class SalaryRateDto : GenericDto
    {
    }

    public class SalaryRateCreateDto
    {
        public string Name { get; set; }
    }
}
