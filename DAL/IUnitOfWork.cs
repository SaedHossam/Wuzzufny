using DAL.Repositories.Interfaces;

namespace DAL
{
    public interface IUnitOfWork
    {
        IApplicationRepository Application { get; }
        ICompanyRepository Companies { get; }
        ICompanyManagerRepository CompaniesManagers { get; }
        IEmployeeRepository Employees { get; }
        IJobRepository Jobs { get; }
        IJobDetailsRepository JobsDetails { get; }
        ISkillRepository Skills { get; }
        ICareerLevelRepository CareerLevel { get; }
        ICityRepository City { get; }
        ICompanyRepository Company { get; }
        ICompanyIndustryRepository CompanyIndustry { get; }
        ICompanyLinksRepository CompanyLinks { get; }
        ICompanySizeRepository CompanySize { get; }
        ICompanyTypeRepository CompanyType { get; }
        ICountryRepository Country { get; }
        ICurrencyRepository Currency { get; }
        IEducationLevelRepository EducationLevel { get; }
        IEmployeeLinksRepository EmployeeLinks { get; }
        IJobCategoryRepository JobCategory { get; }
        IJobTypeRepository JobType { get; }
        ILanguageRepository Language { get; }
        ISalaryRateRepository SalaryRate { get; }
        ISocialLinksRepository SocialLinks { get; }
        IUserLanguageRepository UserLanguage { get; }
        ICompanyRequestStatusRepository CompanyRequestStatus { get; }
        ICompanyApplicationStatusRepository CompanyApplicationStatus { get; }
        int SaveChanges();
    }
}
