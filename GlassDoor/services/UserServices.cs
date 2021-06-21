using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GlassDoor.services
{
    public class UserServices
    {
        protected readonly DbContext _context;
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        private readonly UserManager<ApplicationUser> _userManager;
        public async Task<int?> GetEmployeeId(ClaimsPrincipal user)
        {
            var user1 = await _userManager.GetUserAsync(user);

            if (user1 == null)
                return null;

            var employee = _appContext.Employees.FirstOrDefault(a => a.UserId == user1.Id);
            
            if(employee == null)
                return null;
            
            return employee.Id;
        }
    }
}
