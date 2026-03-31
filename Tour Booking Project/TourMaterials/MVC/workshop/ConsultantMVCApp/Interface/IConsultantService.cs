using ConsultantMVCApp.DTO;

namespace ConsultantMVCApp.Interface
{
    public interface IConsultantService
    {
        Task<List<ConsultantListDto>> GetAllAsync();
        Task<(bool Success, string Error)> CreateAsync(CreateConsultantDto dto);
        Task<ConsultantDetailsDto> GetByIdAsync(Guid id);
       
    }
}
