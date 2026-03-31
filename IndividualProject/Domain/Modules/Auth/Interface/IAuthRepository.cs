using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Auth.Interface
{
    public interface IAuthRepository
    {
        Task<bool> UserExistsAync(string email);
        Task<bool> UserNameExistsAsync(string userName);   

        Task<AppUser> GetByEmailAsync(string email);
        Task CreateUserAsync(AppUser user);
        Task UpdateUserAsync(AppUser user);
    }
}
