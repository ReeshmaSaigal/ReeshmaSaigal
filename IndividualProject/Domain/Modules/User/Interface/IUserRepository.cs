using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Modules.User.Interface
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAllAsync();
        Task<AppUser?> GetByIdAsync(Guid id);
        Task<AppUser?> GetByEmailAsync(string email);
        //Task AddAsync(AppUser user);
        Task<AppUser> UpdateAsync(AppUser user);
        Task<AppUser> DeleteAsync(AppUser user);
    }
}
