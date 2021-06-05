using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        IEnumerable<Job> GetAllJobData();
        public Job GetJobById(int id);

       
       
    }
}
