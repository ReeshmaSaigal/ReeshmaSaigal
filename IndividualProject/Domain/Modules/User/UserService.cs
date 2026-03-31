using AutoMapper;
using Domain.Models;
using Domain.Enums;
using Domain.Modules.User.DTO;
using Domain.Modules.User.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public async Task<UserResponseDto> GetByIdAsync(Guid id)
        {
            var user = await _repo.GetByIdAsync(id)
                ?? throw new Exception("User not found");

            return _mapper.Map<UserResponseDto>(user);
        }

        //public async Task CreateAsync(CreateUserDto request)
        //{
        //    var exists = await _repo.GetByEmailAsync(request.Email);
        //    if (exists != null)
        //        throw new Exception("Email already exists");

        //    var user = new AppUser
        //    {
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        UserName = request.UserName,
        //        Email = request.Email,
        //        Role = UserRole.Staff,
        //        PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        //    };

        //    await _repo.AddAsync(user);
        //}

        public async Task<UserResponseDto> UpdateAsync(Guid id, UpdateUserDto request)
        {
            var user = await _repo.GetByIdAsync(id)
                ?? throw new Exception("User not found");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Role =UserRole.Staff;

           var updateUser= await _repo.UpdateAsync(user);
            return _mapper.Map<UserResponseDto>(updateUser);
            
        }

        public async Task<UserResponseDto> DeleteAsync(Guid id)
        {
            var user = await _repo.GetByIdAsync(id)
                ?? throw new Exception("User not found");

            var deletedUser=await _repo.DeleteAsync(user);
            return _mapper.Map<UserResponseDto>(deletedUser);
        }

        public async Task<bool> ToggleStatusAsync(Guid id)
        {
            var user = await _repo.GetByIdAsync(id)
                ?? throw new Exception("User not found");

            user.IsActive = !user.IsActive;
            await _repo.UpdateAsync(user);
            return user.IsActive;
        }
    }
}
