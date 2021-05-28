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


        int SaveChanges();
    }
}
