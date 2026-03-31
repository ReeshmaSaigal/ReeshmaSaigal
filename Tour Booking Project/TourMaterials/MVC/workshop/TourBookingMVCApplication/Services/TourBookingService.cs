using AutoMapper;
using TourBookingMVCApplication.Models;
using TourBookingMVCApplication.Interfaces;
using TourBookingMVCApplication.DTO;

namespace TourBookingMVCApplication.Services
{
    public class TourBookingService : ITourBookingService
    {
        private readonly ITourBookingRepository _repository;
        private readonly IMapper _mapper;

        public TourBookingService(ITourBookingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> IsAlreadyBooked(Guid userId, Guid tourId)
        {
           return await _repository.IsAlreadyBooked(userId,tourId);
      
        }
        public async Task<List<TourDto>> GetAllToursAsync()
        {
            var tours = await _repository.GetAllToursAsync();
            return _mapper.Map<List<TourDto>>(tours);
        }

        public async Task<TourBookingDto?> GetByIdAsync(Guid id)
        {
            var booking = await _repository.GetByIdAsync(id);
            return _mapper.Map<TourBookingDto?>(booking);
        }
        public async Task<TourDto?> GetByIdTourAsync(Guid id)
        {
            var tour = await _repository.GetByIdTourAsync(id);
            return _mapper.Map<TourDto?>(tour);
        }
        public async Task<TourBookingDto> CreateAsync(CreateBookingDto dto,Guid id)
        {   
            dto.TourId = id;
            
            var entity = _mapper.Map<TourBookingForm>(dto);
            var booking = await _repository.AddAsync(entity);
           return _mapper.Map<TourBookingDto>(booking );

        }

             
    }
}
