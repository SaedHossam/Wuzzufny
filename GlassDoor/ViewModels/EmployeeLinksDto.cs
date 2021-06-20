using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class EmployeeLinksDto:GenericDto
    {
        public string Link { get; set; }
    }

    public class UpdateEmployeeLinksDto
    {
        public string Link { get; set; }
        public string Name { get; set; }
    }
}
