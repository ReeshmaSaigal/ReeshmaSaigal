using Microsoft.EntityFrameworkCore;
using TourDestinationMVCApp.Interfaces;
using TourDestinationMVCApp.Models;

namespace TourDestinationMVCApp.Services
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DestinationDbContext _context;
        public DestinationRepository(DestinationDbContext context) { _context = context; }

        public async Task AddAsync(Destination d)
        {
            await _context.Destinations.AddAsync(d);
        }

        public async Task DeleteAsync(Destination destination)
        {
            _context.Destinations.Remove(destination);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destinations.ToListAsync();
        }

        public async Task<Destination?> GetByIdAsync(Guid id)
        {
            return await _context.Destinations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destinations.Update(destination);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Destinations.AnyAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
