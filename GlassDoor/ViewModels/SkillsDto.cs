using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    // TODO: rename to SkillDto(without 's')
    public class SkillsDto : GenericDto
    {

    }
    public class SkillsCreateDto
    {
        public string Name { get; set; }
    }
    public class SkillsMatching : GenericDto
    {
        public bool Match { get; set; }
    }
}
