using ConsultantMVCApp.Models;

namespace ConsultantMVCApp.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUserNameAsync(string username);
        Task<User> GetByIdAsync(Guid id);
        Task CreateAsync(User user);
        Task SaveChangesAsync();
    }
}
