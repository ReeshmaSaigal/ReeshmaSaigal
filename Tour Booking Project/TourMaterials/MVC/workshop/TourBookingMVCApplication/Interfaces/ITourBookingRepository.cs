using TourBookingMVCApplication.DTO;
using TourBookingMVCApplication.Models;

namespace TourBookingMVCApplication.Interfaces
{
    public interface ITourBookingRepository
    {
        Task<List<Tour>> GetAllToursAsync();

        Task<bool> IsAlreadyBooked(Guid userId, Guid tourId);

        Task<TourBookingForm> GetByIdAsync(Guid id);
        Task<Tour> GetByIdTourAsync(Guid id);
        Task<TourBookingForm> AddAsync(TourBookingForm booking);
    }
}
