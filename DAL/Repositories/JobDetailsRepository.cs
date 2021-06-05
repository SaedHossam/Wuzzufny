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
            //return _appContext.JobsDetails.Include(j=>j.Job).Include(c=>c.CareerLevel).Include(e=>e.EducationLevel).Include(s => s.SalaryCurrency).Include(c=>c.Category)
            //    .FirstOrDefault(a => a.JobId == id);
            return _appContext.JobsDetails.Include(a=>a.Job).ThenInclude(c=>c.Country).ThenInclude(c=>c.Cities).FirstOrDefault(a=>a.JobId == id);


        }

    }
}
