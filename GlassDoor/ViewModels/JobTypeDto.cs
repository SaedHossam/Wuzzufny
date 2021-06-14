using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlassDoor.ViewModels.shared;

namespace GlassDoor.ViewModels
{
    public class JobTypeDto : GenericDto
    {

    }

    public class JobTypeCreateDto
    {
        public string Name { get; set; }
    }
}
