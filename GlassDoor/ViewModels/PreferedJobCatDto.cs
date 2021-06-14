using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class PreferedJobCatDto
    {
        //public int EmpId { get; set; }
        public ICollection< int> PreferredJobCategories { get; set; }
    }
}
