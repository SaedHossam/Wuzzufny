using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlassDoor.Models;

namespace GlassDoor.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);

        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
