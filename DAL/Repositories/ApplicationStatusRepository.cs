using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ApplicationStatusRepository : Repository<ApplicationStatus>, IApplicationStatus
    {
        public ApplicationStatusRepository(ApplicationDbContext context) : base(context)
        { }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
