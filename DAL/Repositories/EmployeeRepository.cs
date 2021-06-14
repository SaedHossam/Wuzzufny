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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public IEnumerable<Employee> GetEmployeeData()
        {
            return _appContext.Employees
                 .Include(c => c.City)
                 .Include(c => c.Country)
                 .Include(c => c.CareerLevel)
                 .Include(c => c.JobTypes)
                 .Include(c => c.Skills)
                 .Include(c => c.UserLanguages).ThenInclude(l => l.Language)
                 .Include(c => c.EmployeeLinks)
                 .Include(c => c.EducationLevel)
                 .Include(c => c.Nationality)
                 .Include(c => c.PreferredJobCategories)
                 .Include(c => c.User).ToList();

        }

        public Employee GetEmployeeDataById(int id)
        {
            return _appContext.Employees
               .Include(c => c.City)
               .Include(c => c.Country)
               .Include(c => c.CareerLevel)
               .Include(c => c.JobTypes)
               .Include(c => c.Skills)
               .Include(c => c.UserLanguages).ThenInclude(l => l.Language)
               .Include(c => c.EmployeeLinks)
               .Include(c => c.EducationLevel)
               .Include(c => c.Nationality)
               .Include(c => c.PreferredJobCategories)
               .Include(c => c.User).FirstOrDefault(a => a.Id == id);
        }

        public Employee GetJobCateogyForOneEmp(int id)
        {
            return _appContext.Employees.Where(j => j.Id == id).Include(e => e.PreferredJobCategories).FirstOrDefault();
        }

        public Employee GetEmpSkills(int id)
        {
            return _appContext.Employees.Where(j => j.Id == id).Include(e => e.Skills).FirstOrDefault();
        }
        public Employee GetEmpJobTypes(int id)
        {
            return _appContext.Employees.Where(j => j.Id == id).Include(e => e.JobTypes).FirstOrDefault();
        }

        public Employee GetEmpLanguages(int id)
        {
            return _appContext.Employees.Where(j => j.Id == id).Include(e => e.UserLanguages).FirstOrDefault();

        }
        public Employee GetEmpLinks(int id)
        {
            return _appContext.Employees.Where(j => j.Id == id).Include(e => e.EmployeeLinks).FirstOrDefault();

        }

        public Employee GetEmpData(int id)
        {
            return _appContext.Employees.FirstOrDefault(e => e.Id == id);
        }



    }
}
