using ConsultantMVCApp.Models;

namespace ConsultantMVCApp.Interface
{
    public interface IConsultantRepository
    {
       
            Task<List<User>> GetAllConsultantsAsync();
            Task<User?> GetByIdAsync(Guid id);
            Task UpdateAsync(User user);
            Task DeleteAsync(User user);
            Task AddAsync(User user);
            Task SaveAsync();
       
    }
}
