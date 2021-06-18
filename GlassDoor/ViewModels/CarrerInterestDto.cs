using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CarrerInterestDto
    {
        // rename the class name from PreferedJobCatDto to Carrer Interest
        //public int EmpId { get; set; }
        public ICollection< int> PreferredJobCategories { get; set; }
        public ICollection<int> JobTypeId { get; set; }
        public int MinimumSalary { get; set; }
        public int? CareerLevelId { get; set; }

    }
}
