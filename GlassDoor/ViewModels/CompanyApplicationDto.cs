using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanyApplicationDto
    {
        public int Id { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Status { get; set; }
        public CompanyEmployeeDto Employee { get; set; }
    }
      
    
}
