using AutoMapper;
using TourDestinationMVCApp.DTO;
using TourDestinationMVCApp.Interfaces;
using TourDestinationMVCApp.Models;

namespace TourDestinationMVCApp.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public DestinationService(IDestinationRepository repo, IMapper mapper, IWebHostEnvironment env)
        {
            _repo = repo;
            _mapper = mapper;
            _env = env;
        }

        public async Task<DestinationResponseDto> CreateAsync(DestinationDto dto)
        {
            var entity = new Destination
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                City = dto.City
            };

            if (dto.ImageFile != null)
            {
                entity.ImageUrl = await SaveImage(dto.ImageFile);
            }

            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();

            return _mapper.Map<DestinationResponseDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var dest = await _repo.GetByIdAsync(id);
            if (dest == null) return false;

            // optionally delete image file
            if (!string.IsNullOrEmpty(dest.ImageUrl))
            {
                TryDeleteFile(dest.ImageUrl);
            }

            await _repo.DeleteAsync(dest);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DestinationResponseDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<DestinationResponseDto>>(items);
        }

        public async Task<DestinationResponseDto?> GetByIdAsync(Guid id)
        {
            var dest = await _repo.GetByIdAsync(id);
            if (dest == null) return null;
            return _mapper.Map<DestinationResponseDto>(dest);
        }

        public async Task<DestinationResponseDto?> UpdateAsync(Guid id, DestinationDto dto)
        {
            var dest = await _repo.GetByIdAsync(id);
            if (dest == null) return null;

            dest.Name = dto.Name;
            dest.City = dto.City;

            if (dto.ImageFile != null)
            {
                // delete old
                if (!string.IsNullOrEmpty(dest.ImageUrl))
                    TryDeleteFile(dest.ImageUrl);

                dest.ImageUrl = await SaveImage(dto.ImageFile);
            }

            await _repo.UpdateAsync(dest);
            await _repo.SaveChangesAsync();

            return _mapper.Map<DestinationResponseDto>(dest);
        }

        public async Task<DestinationResponseDto?> PatchAsync(Guid id, DestinationPatchDto patchDto)
        {
            var dest = await _repo.GetByIdAsync(id);
            if (dest == null) return null;

            if (patchDto.Name != null) dest.Name = patchDto.Name;
            if (patchDto.City != null) dest.City = patchDto.City;

            if (patchDto.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(dest.ImageUrl))
                    TryDeleteFile(dest.ImageUrl);
                dest.ImageUrl = await SaveImage(patchDto.ImageFile);
            }

            await _repo.UpdateAsync(dest);
            await _repo.SaveChangesAsync();

            return _mapper.Map<DestinationResponseDto>(dest);
        }

        private async Task<string> SaveImage(IFormFile file)
        {
            if (file == null || file.Length == 0) return null;

            var uploads = Path.Combine(_env.WebRootPath, "uploads", "destinations");
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(uploads, fileName);

            using (var fs = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            // return relative path for use in <img src="~/uploads/destinations/..." />
            return $"/uploads/destinations/{fileName}";
        }

        private void TryDeleteFile(string relativeUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(relativeUrl)) return;
                var path = relativeUrl.StartsWith("/") ? relativeUrl.Substring(1) : relativeUrl;
                var full = Path.Combine(_env.WebRootPath, path.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(full)) File.Delete(full);
            }
            catch { /* swallow for safety */ }
        }
    }
}
