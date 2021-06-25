using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Shared
{
    public abstract class GenericModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
