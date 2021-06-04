using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(ApplicationDbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;


        public IEnumerable<Job> GetAllJobData()
        {
            return _appContext.Jobs
                .Include(a => a.Applications)
                .Include(j => j.JobDetails)
                .Include(c => c.Company).Include(s=>s.Skills).Include(c=>c.City)
                .Include(c=>c.Country)
                .Include(j=>j.JobType)                
                .ToList();
        }

         public Job GetJobById(int id)
        {
            return _appContext.Jobs.Include(s=>s.Skills).Include(c=>c.Company).Include(c=>c.City).Include(c=>c.Country)
                .Include(j=>j.JobType)
                .Where(a=>a.Id==id).FirstOrDefault();
                
        }
    }
}
