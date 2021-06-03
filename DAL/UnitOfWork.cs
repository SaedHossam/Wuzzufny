using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IApplicationRepository _application;
        private ICompanyRepository _companies;
        private ICompanyManagerRepository _companiesManagers;
        private IEmployeeRepository _employees;
        private IJobRepository _jobs;
        private IJobDetailsRepository _jobsDetails;
        private ISkillRepository _skills;
        private ICareerLevelRepository _careerLevel;
        private ICityRepository _city;
        private ICompanyRepository _company;
        private ICompanyIndustryRepository _companyIndustry;
        private ICompanyLinksRepository _companyLinks;
        private ICompanySizeRepository _companySize;
        private ICompanyTypeRepository _companyType;
        private ICountryRepository _country;
        private ICurrencyRepository _currency;
        private IEducationLevelRepository _educationLevel;
        private IEmployeeLinksRepository _employeeLinks;
        private IJobCategoryRepository _jobCategory;
        private IJobTypeRepository _jobType;
        private ILanguageRepository _language;
        private ISalaryRateRepository _salaryRate;
        private ISocialLinksRepository _socialLinks;
        private IUserLanguageRepository _userLanguage;

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
        public ICareerLevelRepository CareerLevel => _careerLevel ??= new CareerLevelRepository(_context);
        public ICityRepository City => _city ??= new CityRepository(_context);
        public ICompanyRepository Company => _company ??= new CompanyRepository(_context);
        public ICompanyIndustryRepository CompanyIndustry => _companyIndustry ??= new CompanyIndustryRepository(_context);
        public ICompanyLinksRepository CompanyLinks => _companyLinks ??= new CompanyLinksRepository(_context);
        public ICompanySizeRepository CompanySize => _companySize ??= new CompanySizeRepository(_context);
        public ICompanyTypeRepository CompanyType => _companyType ??= new CompanyTypeRepository(_context);
        public ICountryRepository Country => _country ??= new CountryRepository(_context);
        public ICurrencyRepository Currency => _currency ??= new CurrencyRepository(_context);
        public IEducationLevelRepository EducationLevel => _educationLevel ??= new EducationLevelRepository(_context);
        public IEmployeeLinksRepository EmployeeLinks => _employeeLinks ??= new EmployeeLinksRepository(_context);
        public IJobCategoryRepository JobCategory => _jobCategory ??= new JobCategoryRepository(_context);
        public IJobTypeRepository JobType => _jobType ??= new JobTypeRepository(_context);
        public ILanguageRepository Language => _language ??= new LanguageRepository(_context);
        public ISalaryRateRepository SalaryRate => _salaryRate ??= new SalaryRateRepository(_context);
        public ISocialLinksRepository SocialLinks => _socialLinks ??= new SocialLinksRepository(_context);
        public IUserLanguageRepository UserLanguage => _userLanguage ??= new UserLanguageRepository(_context);




        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
