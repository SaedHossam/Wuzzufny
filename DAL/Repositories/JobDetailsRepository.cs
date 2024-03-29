﻿using System;
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

            return _appContext.JobsDetails
                .Include(j => j.Job)
                .Include(c => c.CareerLevel)
                .Include(e => e.EducationLevel)
                .Include(s => s.SalaryCurrency)
                .Include(c => c.JobCategory)
                .Include(c => c.Job.Country)
                .Include(c => c.Job.City)
                .Include(c => c.Job.Skills)
                    .ThenInclude(js => js.Skills)
                .Include(s => s.SalaryRate)
                .Include(c => c.Job.Company)
                    .ThenInclude(d => d.CompanyIndustry)
                .Include(c => c.Job.JobType)
                .FirstOrDefault(a => a.JobId == id);
        }
    }
}
