using Domain.Modules.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.User.Interface
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto> GetByIdAsync(Guid id);
        //Task<UserResponseDto> CreateAsync(CreateUserDto request);
        Task<UserResponseDto> UpdateAsync(Guid id, UpdateUserDto request);
        Task<UserResponseDto> DeleteAsync(Guid id);
        Task<bool> ToggleStatusAsync(Guid id);
    }
}
