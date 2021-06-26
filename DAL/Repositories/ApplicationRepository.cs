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
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        public ApplicationRepository(ApplicationDbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        public IEnumerable<Application> GetEmployeeApplications( int id)
        {
            return _appContext.Applications
                .Include(a => a.Job)
                .ThenInclude(b => b.Company)
                .ThenInclude(c => c.CompanyIndustry)
                .Include(c => c.Job).ThenInclude(d => d.City)
                .Include(c => c.Job).ThenInclude(d => d.JobType)
                .Include(c => c.Job).ThenInclude(d => d.Country)
                .Include(c => c.ApplicationStatus)
                .Where(a => a.EmployeeId == id && a.IsWithdrawn == false)
                .OrderByDescending(a => a.ApplyDate)
                .ToList();
        }

        public IEnumerable<Application> GetEmployeeArchivedApplications(int id)
        {
            return _appContext.Applications
                .Include(a => a.Job)
                .ThenInclude(b => b.Company)
                .ThenInclude(c => c.CompanyIndustry)
                .Include(c => c.Job).ThenInclude(d => d.City)
                .Include(c => c.Job).ThenInclude(d => d.JobType)
                .Include(c => c.Job).ThenInclude(d => d.Country)
                .Include(c => c.ApplicationStatus)
                .Where(a => a.EmployeeId == id && a.IsArchived == true && a.IsWithdrawn == false)
                .ToList();
        }
    }
}
