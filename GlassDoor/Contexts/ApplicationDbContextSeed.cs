using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using GlassDoor.Constants;
using JsonNet.PrivateSettersContractResolvers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace GlassDoor.Contexts
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IHost host)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Employee.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Company.ToString()));

            //Seed Default User
            var adminUser = new ApplicationUser
            {
                UserName = Authorization.AdminUserName,
                Email = Authorization.AdminEmail,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != adminUser.Id))
            {
                await userManager.CreateAsync(adminUser, Authorization.AdminPassword);
                await userManager.AddToRoleAsync(adminUser, Authorization.AdminRole.ToString());
            }

            var companyUser = new ApplicationUser
            {
                UserName = Authorization.CompanyUserName,
                Email = Authorization.CompanyEmail,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != companyUser.Id))
            {
                await userManager.CreateAsync(companyUser, Authorization.CompanyPassword);
                await userManager.AddToRoleAsync(companyUser, Authorization.CompanyRole.ToString());
            }

            var employeeUser = new ApplicationUser
            {
                UserName = Authorization.EmployeeUserName,
                Email = Authorization.EmployeeEmail,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                FirstName = "first",
                LastName = "last"
            };

            if (userManager.Users.All(u => u.Id != employeeUser.Id))
            {
                await userManager.CreateAsync(employeeUser, Authorization.EmployeePassword);
                await userManager.AddToRoleAsync(employeeUser, Authorization.EmployeeRole.ToString());
            }

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();

            if (!context.Skills.Any())
            {
                var skills = new List<Skill>()
                {
                    new Skill() {Name = "html"},
                    new Skill() {Name = "css"},
                    new Skill() {Name = "JavaScript"},
                    new Skill() {Name = "C#"},
                    new Skill() {Name = "bootstrap"},

                };

                await context.Skills.AddRangeAsync(skills);
                await context.SaveChangesAsync();
            }

            if (!context.CareerLevels.Any())
            {
                var careerLevels = new List<CareerLevel>()
                {
                    new CareerLevel() {Name = "Experienced"},
                    new CareerLevel() {Name = "Manager"},
                    new CareerLevel() {Name = "Senior Management"},
                    new CareerLevel() {Name = "Entry Level"},
                    new CareerLevel() {Name = "Student"},
                };

                await context.CareerLevels.AddRangeAsync(careerLevels);
                await context.SaveChangesAsync();
            }

            if (!context.CompanyIndustries.Any())
            {
                var companyIndustries = new List<CompanyIndustry>()
                {
                    new CompanyIndustry() {Name = "IT"}
                };

                await context.CompanyIndustries.AddRangeAsync(companyIndustries);
                await context.SaveChangesAsync();
            }

            if (!context.CompanySizes.Any())
            {
                var companySizes = new List<CompanySize>()
                {
                    new CompanySize() {Name = "< 50 Employee"},
                    new CompanySize() {Name = "50 : 100 Employee"},
                    new CompanySize() {Name = "100 : 500 Employee"},
                    new CompanySize() {Name = "500 : 1000 Employee"},
                    new CompanySize() {Name = "> 1000 Employee"}
                };

                await context.CompanySizes.AddRangeAsync(companySizes);
                await context.SaveChangesAsync();
            }

            if (!context.CompanyTypes.Any())
            {
                var companyTypes = new List<CompanyType>()
                {
                    new CompanyType() {Name = "Public Company"},
                    new CompanyType() {Name = "Privately held"},
                    new CompanyType() {Name = "Recruitment Agency"},
                    new CompanyType() {Name = "Educational Institution"},
                    new CompanyType() {Name = "Government Agency"},
                    new CompanyType() {Name = "Non-profit"},
                };

                await context.CompanyTypes.AddRangeAsync(companyTypes);
                await context.SaveChangesAsync();
            }

            if (!context.EducationLevels.Any())
            {
                var educationLevels = new List<EducationLevel>()
                {
                    new EducationLevel() {Name = "Bachelor's Degree"},
                    new EducationLevel() {Name = "Master's Degree"},
                    new EducationLevel() {Name = "Doctorate Degree"},
                    new EducationLevel() {Name = "High School"},
                    new EducationLevel() {Name = "Vocational"},
                    new EducationLevel() {Name = "Diploma"}
                };

                await context.EducationLevels.AddRangeAsync(educationLevels);
                await context.SaveChangesAsync();
            }

            if (!context.JobCategories.Any())
            {
                var jobCategories = new List<JobCategory>()
                {
                    new JobCategory() {Name = "Front End"},
                    new JobCategory() {Name = "Back End"},
                    new JobCategory() {Name = "Full Stack"},
                    new JobCategory() {Name = "Mobile Native"},
                    new JobCategory() {Name = "Mobile Cross platform"}
                };

                await context.JobCategories.AddRangeAsync(jobCategories);
                await context.SaveChangesAsync();
            }


            if (!context.JobTypes.Any())
            {
                var jobTypes = new List<JobType>()
                {
                    new JobType() {Name = "Full Time"},
                    new JobType() {Name = "Part Time"},
                    new JobType() {Name = "Freelance / Project"},
                    new JobType() {Name = "Shift Based"},
                    new JobType() {Name = "Work From Home"},
                    new JobType() {Name = "Volunteering"},

                };

                await context.JobTypes.AddRangeAsync(jobTypes);
                await context.SaveChangesAsync();
            }

            if (!context.Languages.Any())
            {
                var languages = new List<Language>()
                {
                    new Language() {Name = "Arabic"},
                    new Language() {Name = "English"}
                };

                await context.Languages.AddRangeAsync(languages);
                await context.SaveChangesAsync();
            }

            if (!context.SalaryRates.Any())
            {
                var salaryRates = new List<SalaryRate>()
                {
                    new SalaryRate() {Name = "Per Hour"},
                    new SalaryRate() {Name = "Per Day"},
                    new SalaryRate() {Name = "Per Week"},
                    new SalaryRate() {Name = "Per Month"},
                    new SalaryRate() {Name = "Per Year"}
                };

                await context.SalaryRates.AddRangeAsync(salaryRates);
                await context.SaveChangesAsync();
            }

            if (!context.CompanyRequestStatus.Any())
            {
                var companyRequestStatuses = new List<CompanyRequestStatus>()
                {
                    new CompanyRequestStatus() {Name = Enums.CompanyRequestStatus.UnderReview.ToString()},
                    new CompanyRequestStatus() {Name = Enums.CompanyRequestStatus.Accepted.ToString()},
                    new CompanyRequestStatus() {Name = Enums.CompanyRequestStatus.Rejected.ToString()}
                };

                await context.CompanyRequestStatus.AddRangeAsync(companyRequestStatuses);
                await context.SaveChangesAsync();
            }

            if (!context.ApplicationStatuses.Any())
            {
                var applicationStatus = new List<ApplicationStatus>()
                {
                    new ApplicationStatus() {Name = Enums.ApplicationStatus.Applied.ToString()},
                    new ApplicationStatus() {Name = Enums.ApplicationStatus.Viewed.ToString()},
                    new ApplicationStatus() {Name = Enums.ApplicationStatus.InConsidration.ToString()},
                    new ApplicationStatus() {Name = Enums.ApplicationStatus.Rejected.ToString()},
                    new ApplicationStatus() {Name = Enums.ApplicationStatus.Hired.ToString()},

                };

                await context.ApplicationStatuses.AddRangeAsync(applicationStatus);
                await context.SaveChangesAsync();
            }

            if (!context.Employees.Any())
            {
                var employee = new Employee() { UserId = employeeUser.Id };
                context.Employees.Add(employee);
                context.SaveChanges();
            }

            if (!context.Companies.Any())
            {
                var company = new Company()
                {
                    Name = "company",
                    CompanyIndustryId = context.CompanyIndustries.First().Id,
                    CompanySizeId = context.CompanySizes.First().Id,
                    CompanyTypeId = context.CompanyTypes.First().Id,
                    RequestStatusId = context.CompanyRequestStatus
                        .First(r => r.Name == Enums.CompanyRequestStatus.Accepted.ToString()).Id,
                    Logo = "/Resources/company-logos/company-placeholder.png"
                };

                context.Companies.Add(company);
                context.SaveChanges();

                var companyManager = new CompanyManager()
                {
                    UserId = companyUser.Id,
                    CompanyId = context.Companies.First().Id,
                    Title = "Hr",
                };
                context.CompanyManagers.Add(companyManager);
                context.SaveChanges();
            }
        }
    }
}
