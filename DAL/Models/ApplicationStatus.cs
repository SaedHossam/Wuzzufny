using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ApplicationStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Application> Applications { get; set; }

    }
}
