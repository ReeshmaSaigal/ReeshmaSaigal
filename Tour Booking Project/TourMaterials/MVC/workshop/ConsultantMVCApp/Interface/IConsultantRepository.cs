using ConsultantMVCApp.Models;

namespace ConsultantMVCApp.Interface
{
    public interface IConsultantRepository
    {
       
            Task<List<User>> GetAllConsultantsAsync();
            Task<User?> GetByIdAsync(Guid id);
            Task AddAsync(User user);
            Task SaveAsync();
       
    }
}
