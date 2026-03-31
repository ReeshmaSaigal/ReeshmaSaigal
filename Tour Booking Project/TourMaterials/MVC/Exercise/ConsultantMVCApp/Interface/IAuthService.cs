using ConsultantMVCApp.Models;
using ConsultantMVCApp.DTO;

namespace ConsultantMVCApp.Interfaces
{
    public interface IAuthService
    {
        Task<(bool Success, string? Error)> RegisterAsync(AuthUserDto user, string passwordPlain);
        Task<(bool Success, User? User, string? Error)> ValidateUserAsync(string usernameOrEmail, string passwordPlain);
    }
}
