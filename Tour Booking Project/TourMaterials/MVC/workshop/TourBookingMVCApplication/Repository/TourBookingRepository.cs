
using Microsoft.EntityFrameworkCore;
using TourBookingMVCApplication.Models;
using TourBookingMVCApplication.Interfaces;
using TourBookingMVCApplication.DTO;

namespace TourBookingMVCApplication.Repository
{
    public class TourBookingRepository : ITourBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public TourBookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Tour>> GetAllToursAsync()
        {
            return await _context.Tours.ToListAsync();
        }
        public async Task<bool> IsAlreadyBooked(Guid userId, Guid tourId)
        {
            return await _context.TourBookingForms
                                 .AnyAsync(x => x.UserId == userId
                                             && x.TourId == tourId);
        }
        public async Task<TourBookingForm> GetByIdAsync(Guid id)
            => await _context.TourBookingForms.FindAsync(id);
        public async Task<Tour> GetByIdTourAsync(Guid id)
           => await _context.Tours.FindAsync(id);
        public async Task<TourBookingForm> AddAsync(TourBookingForm booking)
        {
            
            _context.TourBookingForms.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }


       
    }
}
