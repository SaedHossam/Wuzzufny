using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IJobDetailsRepository : IRepository<JobDetails>
    {
        public JobDetails GetJobDetails(int id);
    }
}
