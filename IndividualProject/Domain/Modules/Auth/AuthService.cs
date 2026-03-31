using Domain.Models;
using Domain.Modules.Auth.DTO;
using Domain.Modules.Auth.Interface;
using Domain.Helper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Modules.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly IJwtHelper _jwtHelper;
        private readonly IEmailHelper _emailHelper;

        public AuthService(
            IAuthRepository authRepository,
            IMapper mapper,
            IJwtHelper jwtHelper,
            IEmailHelper emailHelper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            _emailHelper = emailHelper;
        }

        public async Task<AuthResponseDto> RegisterUserAsync(RegisterDto dto)
        {
            if (await _authRepository.UserExistsAync(dto.Email))
                throw new Exception("User with this email already exists.");

            if (await _authRepository.UserNameExistsAsync(dto.UserName))
                throw new Exception("Username already taken.");

            var user = _mapper.Map<AppUser>(dto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            user.IsActive = true;
            user.CreatedAt = DateTime.UtcNow;
           
            await _authRepository.CreateUserAsync(user);

            var response = _mapper.Map<AuthResponseDto>(user);
            response.Token = _jwtHelper.GenerateJwtToken(user);

            return response;
        }

       

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _authRepository.GetByEmailAsync(dto.Email);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("Invalid email or password.");

            if (!user.IsActive)
                throw new Exception("User account is inactive.");

            var response = _mapper.Map<AuthResponseDto>(user);
            response.Token = _jwtHelper.GenerateJwtToken(user);

            return response;
        }

        public async Task<bool> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            var user = await _authRepository.GetByEmailAsync(dto.Email);
            if (user == null) return true; 

            var resetCode = new Random().Next(100000, 999999).ToString();

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(resetCode);
            await _authRepository.UpdateUserAsync(user);

            await _emailHelper.SendAsync(
                dto.Email,
                "Smart Stock - Password Reset",
                $"Your temporary password is: <b>{resetCode}</b>"
            );

            return true;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _authRepository.GetByEmailAsync(dto.Email);
            if (user == null) return false;

            user.PasswordHash= BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            await _authRepository.UpdateUserAsync(user);
            return true;
        }

       
    }
}