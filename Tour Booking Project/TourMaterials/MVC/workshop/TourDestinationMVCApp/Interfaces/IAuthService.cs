using TourDestinationMVCApp.Models;
using TourDestinationMVCApp.DTO;

namespace TourDestinationMVCApp.Interfaces
{
    public interface IAuthService
    {
        Task<(bool Success, string? Error)> RegisterAsync(AuthUserDto user, string passwordPlain);
        Task<(bool Success, AuthUser? User, string? Error)> ValidateUserAsync(string usernameOrEmail, string passwordPlain);
    }
}
