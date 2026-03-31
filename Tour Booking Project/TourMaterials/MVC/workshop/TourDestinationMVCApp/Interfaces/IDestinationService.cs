using TourDestinationMVCApp.DTO;

namespace TourDestinationMVCApp.Interfaces
{
    public interface IDestinationService
    {
        Task<IEnumerable<DestinationResponseDto>> GetAllAsync();
        Task<DestinationResponseDto?> GetByIdAsync(Guid id);
        Task<DestinationResponseDto> CreateAsync(DestinationDto dto);
        Task<DestinationResponseDto?> UpdateAsync(Guid id, DestinationDto dto);
        Task<DestinationResponseDto?> PatchAsync(Guid id, DestinationPatchDto patchDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
