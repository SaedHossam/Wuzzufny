using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using GlassDoor.Constants;
using Microsoft.AspNetCore.Identity;

namespace GlassDoor.Contexts
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
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
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != employeeUser.Id))
            {
                await userManager.CreateAsync(employeeUser, Authorization.EmployeePassword);
                await userManager.AddToRoleAsync(employeeUser, Authorization.EmployeeRole.ToString());
            }
        }
    }
}
