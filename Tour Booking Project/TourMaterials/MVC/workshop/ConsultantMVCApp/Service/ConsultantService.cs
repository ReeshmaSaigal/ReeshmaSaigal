using ConsultantMVCApp.DTO;
using ConsultantMVCApp.Interface;
using ConsultantMVCApp.Models;
using ConsultantMVCApp.Enum;

using AutoMapper;
using ConsultantMVCApp.Interfaces;

namespace ConsultantMVCApp.Service
{
    public class ConsultantService : IConsultantService
    {
        private readonly IAuthRepository _authRepo;
        private readonly IConsultantRepository _repo;
        private readonly IMapper _mapper;


        public ConsultantService(IConsultantRepository repo ,IAuthRepository authRepo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _authRepo=authRepo;
        }

        public async Task<List<ConsultantListDto>> GetAllAsync()
        {
            var consultants = await _repo.GetAllConsultantsAsync();

            return _mapper.Map<List<ConsultantListDto>>(consultants);
        }

        public async Task<(bool Success, string Error)> CreateAsync(CreateConsultantDto dto)
        {
             var existsEmail = await _authRepo.GetByEmailAsync(dto.Email);
            if (existsEmail != null) return (false, "Email already exists.");

            var existsUser = await _authRepo.GetByUserNameAsync(dto.UserName);
            if (existsUser != null) return (false, "Username already exists.");
            var newuser=_mapper.Map<User>(dto);
            newuser.Role = UserRole.CONSULTANT;
            newuser.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            newuser.Id = Guid.NewGuid();
            newuser.CreatedAt = DateTime.UtcNow;

            await _authRepo.CreateAsync(newuser);
            await _repo.SaveAsync();
            return (true, null);
        }
        public async Task<ConsultantDetailsDto> GetByIdAsync(Guid id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return null;

           return _mapper.Map<ConsultantDetailsDto>(user);
        }

       
    }
}

