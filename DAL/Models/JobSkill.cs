using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class JobSkill
    {
        public int JobsId { get; set; }
        public int SkillsId { get; set; }

        public Job Jobs { get; set; }
        public Skill Skills { get; set; }
    }
}
