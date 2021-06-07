using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class JobCategoryDto : GenericDto
    {

    }

    public class JobCategoryCreateDto
    {
        public string Name { get; set; }
    }
}
