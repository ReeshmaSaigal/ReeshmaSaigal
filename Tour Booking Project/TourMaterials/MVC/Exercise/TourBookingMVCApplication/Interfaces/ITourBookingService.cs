using TourBookingMVCApplication.DTO;

namespace TourBookingMVCApplication.Interfaces
{
    public interface ITourBookingService
    {
        Task<List<TourDto>> GetAllToursAsync();
        Task<bool>IsAlreadyBooked(Guid userId, Guid tourId);
        Task<TourBookingDto?> GetByIdAsync(Guid id);
        Task<TourDto?> GetByIdTourAsync(Guid id);
        Task<TourBookingDto> CreateAsync(CreateBookingDto dto, Guid Id);
        Task UpdateAsync(TourBookingDto dto);
        Task DeleteAsync(Guid id);
    }
}
