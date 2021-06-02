using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserLanguage
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int Level { get; set; }
    }
}
