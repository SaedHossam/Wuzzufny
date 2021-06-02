using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Point Location { get; set; }
        //Location = new Point(16.3738, 48.2082)
        //{
        //    SRID = 4326
        //}

        public Country Country { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
