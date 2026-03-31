using TourDestinationMVCApp.Interfaces;
using TourDestinationMVCApp.Models;
using BCrypt.Net;
using TourDestinationMVCApp.DTO;
using AutoMapper;

namespace TourDestinationMVCApp.Services
{
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository repo ,IMapper mapper)
        { 
            _repo = repo;
            _mapper=mapper;
        }

        public async Task<(bool Success, string? Error)> RegisterAsync(AuthUserDto user, string passwordPlain)
        {
            var existsEmail = await _repo.GetByEmailAsync(user.Email);
            if (existsEmail != null) return (false, "Email already exists.");

            var existsUser = await _repo.GetByUserNameAsync(user.UserName);
            if (existsUser != null) return (false, "Username already exists.");
            var newuser=_mapper.Map<AuthUser>(user);
            newuser.Role = Enum.UserRole.AGENCY;
            newuser.Password = BCrypt.Net.BCrypt.HashPassword(passwordPlain);
            newuser.Id = Guid.NewGuid();
            newuser.CreatedAt = DateTime.UtcNow;

            await _repo.CreateAsync(newuser);
            await _repo.SaveChangesAsync();
            return (true, null);
        }

        public async Task<(bool Success, AuthUser? User, string? Error)> ValidateUserAsync(string usernameOrEmail, string passwordPlain)
        {
            AuthUser? user = await _repo.GetByUserNameAsync(usernameOrEmail)
                                  ?? await _repo.GetByEmailAsync(usernameOrEmail);

            if (user == null) return (false, null, "Invalid username or email.");

            if (!BCrypt.Net.BCrypt.Verify(passwordPlain, user.Password))
                return (false, null, "Invalid password.");
            return (true, user, null);
        }
    }
}

