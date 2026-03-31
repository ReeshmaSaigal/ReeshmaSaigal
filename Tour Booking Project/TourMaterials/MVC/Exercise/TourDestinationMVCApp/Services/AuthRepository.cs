using Microsoft.EntityFrameworkCore;
using TourDestinationMVCApp.Interfaces;
using TourDestinationMVCApp.Models;

namespace TourDestinationMVCApp.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DestinationDbContext _context;
        public AuthRepository(DestinationDbContext context) { _context = context; }

        public async Task CreateAsync(AuthUser user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<AuthUser?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<AuthUser?> GetByUserNameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<AuthUser> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
