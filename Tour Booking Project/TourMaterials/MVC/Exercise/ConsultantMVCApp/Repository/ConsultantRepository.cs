using ConsultantMVCApp.Models;
using ConsultantMVCApp.Interface;
using Microsoft.EntityFrameworkCore;
using ConsultantMVCApp.Enum;

namespace ConsultantMVCApp.Repository
{
    public class ConsultantRepository : IConsultantRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllConsultantsAsync()
        {
            return await _context.Users
                .Where(x => x.Role == (int)UserRole.CONSULTANT)
                .Include(x => x.TourConsultants)
                .Include(x => x.TourBookingForms)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}