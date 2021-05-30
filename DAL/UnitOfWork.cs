using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        private IApplicationRepository _application;
        private ICompanyRepository _companies;
        private ICompanyManagerRepository _companiesManagers;
        private IEmployeeRepository _employees;
        private IJobRepository _jobs;
        private IJobDetailsRepository _jobsDetails;
        private ISkillRepository _skills;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public IApplicationRepository Application => _application ??= new ApplicationRepository(_context);

        public ICompanyRepository Companies => _companies ??= new CompanyRepository(_context);

        public ICompanyManagerRepository CompaniesManagers => _companiesManagers ??= new CompanyManagerRepository(_context);

        public IEmployeeRepository Employees => _employees ??= new EmployeeRepository(_context);

        public IJobRepository Jobs => _jobs ??= new JobRepository(_context);

        public IJobDetailsRepository JobsDetails => _jobsDetails ??= new JobDetailsRepository(_context);

        public ISkillRepository Skills => _skills ??= new SkillRepository(_context);



        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
