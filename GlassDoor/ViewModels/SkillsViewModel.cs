using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace glassDoor.ViewModels
{
    public class SkillsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
