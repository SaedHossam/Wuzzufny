using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class EducationLevelRepository : Repository<EducationLevel>, IEducationLevelRepository
    {
        public EducationLevelRepository(ApplicationDbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
