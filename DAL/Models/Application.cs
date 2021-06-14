using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Application
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
        public int EmployeeId { get; set; }
        public int JobId { get; set; }

        public virtual Employee Employee { get; set; }
        //added job id
        public virtual Job Job { get; set; }
    }
}
