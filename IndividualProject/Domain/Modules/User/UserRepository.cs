using Domain.Models;
using Domain.Modules.User.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Modules.User
{
    public class UserRepository : IUserRepository
    {
        private readonly SmartStockDbContext _context;

        public UserRepository( SmartStockDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
           var user= await _context.Users.ToListAsync();
            return user;


        }

        public async Task<AppUser?> GetByIdAsync(Guid id)
        {

            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<AppUser?> GetByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        //public async Task AddAsync(AppUser user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<AppUser> UpdateAsync(AppUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<AppUser> DeleteAsync(AppUser user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
