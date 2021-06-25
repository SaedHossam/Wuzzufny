using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Symbol{ get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<JobDetails> JobDetails { get; set; }
    }
}
