using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class SkillAndLanguageDto
    {
        public ICollection<int> SkillId { get; set; }
        public ICollection<int> LanguageId { get; set; }
        public int Level { get; set; }
    }
}
