using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Status { get; set; }
        public bool IsViewed { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public bool IsWithdrawn { get; set; }
        public DateTime? WithDrawDate { get; set; }
        public string WithdrawReason { get; set; }
        public EmployeeDto Employee { get; set; }
    }
      
    
}
