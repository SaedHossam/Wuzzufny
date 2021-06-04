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
    public class JobDetailsRepository : Repository<JobDetails>, IJobDetailsRepository
    {
        public JobDetailsRepository(ApplicationDbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;


        public JobDetails GetJobDetails(int id)
        {
            return _appContext.JobsDetails.Include(c=>c.CareerLevel).Include(e=>e.EducationLevel).Include(s => s.SalaryCurrency).Include(c=>c.Category)
                .Where(a => a.JobId == id).FirstOrDefault()
               ;
        }

    }
}
