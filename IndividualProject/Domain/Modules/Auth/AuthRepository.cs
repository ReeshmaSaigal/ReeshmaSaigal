using Domain.Models;
using Domain.Modules.Auth.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Auth
{
    public class AuthRepository:IAuthRepository
    {
        private readonly SmartStockDbContext _context;

        public AuthRepository(SmartStockDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExistsAync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<bool> UserNameExistsAsync(string userName)
        {
            return await _context.Users
                .AnyAsync(u => u.UserName == userName);
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task CreateUserAsync(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(AppUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
    

