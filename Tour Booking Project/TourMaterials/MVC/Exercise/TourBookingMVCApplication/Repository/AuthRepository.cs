using Microsoft.EntityFrameworkCore;
using TourBookingMVCApplication.Interfaces;
using TourBookingMVCApplication.Models;

namespace TourBookingMVCApplication.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context) { _context = context; }

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
