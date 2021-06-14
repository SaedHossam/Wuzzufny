using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IApplicationRepository : IRepository<Application>
    {
        public IEnumerable<Application> GetEmployeeApplications(int id);

    }
}
