using ConsultantMVCApp.Interfaces;
using ConsultantMVCApp.Models;
using ConsultantMVCApp.Enum;
using BCrypt.Net;
using ConsultantMVCApp.DTO;
using AutoMapper;

namespace ConsultantMVCApp.Services
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
            var newuser=_mapper.Map<User>(user);
            newuser.Role = UserRole.CUSTOMER;
            newuser.Password = BCrypt.Net.BCrypt.HashPassword(passwordPlain);
            newuser.Id = Guid.NewGuid();
            newuser.CreatedAt = DateTime.UtcNow;

            await _repo.CreateAsync(newuser);
            await _repo.SaveChangesAsync();
            return (true, null);
        }

        public async Task<(bool Success, User? User, string? Error)> ValidateUserAsync(string userName, string passwordPlain)
        {
            User user =await _repo.GetByUserNameAsync(userName);

            if (user == null) return (false, null, "Invalid username");
            var password = BCrypt.Net.BCrypt.HashPassword(passwordPlain);
            if (!BCrypt.Net.BCrypt.Verify(passwordPlain, user.Password))
                return (false, null, "Invalid password.");
            return (true, user, null);
        }
    }
}

