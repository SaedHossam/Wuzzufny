using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanyTypeDto : GenericDto
    {

    }

    public class CompanyTypeCreateDto
    {
        public string Name { get; set; }
    }
}
