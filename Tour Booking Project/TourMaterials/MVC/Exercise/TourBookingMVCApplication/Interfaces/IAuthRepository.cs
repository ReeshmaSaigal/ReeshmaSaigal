using TourBookingMVCApplication.Models;

namespace TourBookingMVCApplication.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthUser?> GetByEmailAsync(string email);
        Task<AuthUser?> GetByUserNameAsync(string username);
        Task<AuthUser> GetByIdAsync(Guid id);
        Task CreateAsync(AuthUser user);
        Task SaveChangesAsync();
    }
}
