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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        public Company GetCompany(int id)
        {
            return _appContext.Companies
                .Include(a => a.Locations)
                .ThenInclude(a => a.cities).ThenInclude(c => c.Country)
                .Include(a => a.CompanyLinks)
                .Include(a => a.CompanyIndustry)
                .Include(a => a.CompanySize)
                .Include(a => a.CompanyType)
                .Include(a => a.Locations)
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
