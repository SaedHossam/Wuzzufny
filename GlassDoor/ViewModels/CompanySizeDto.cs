using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlassDoor.ViewModels.shared;

namespace GlassDoor.ViewModels
{
    public class CompanySizeDto: GenericDto
    {

    }

    public class CompanySizeCreateDto
    {
        public string Name { get; set; }
    }
}
