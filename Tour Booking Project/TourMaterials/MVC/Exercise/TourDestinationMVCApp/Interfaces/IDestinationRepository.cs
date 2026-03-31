using TourDestinationMVCApp.Models;

namespace TourDestinationMVCApp.Interfaces
{
    public interface IDestinationRepository
    {
        Task<IEnumerable<Destination>> GetAllAsync();
        Task<Destination?> GetByIdAsync(Guid id);
        Task AddAsync(Destination destination);
        Task UpdateAsync(Destination destination);
        Task DeleteAsync(Destination destination);
        Task<bool> ExistsAsync(Guid id);
        Task SaveChangesAsync();
    }
}
