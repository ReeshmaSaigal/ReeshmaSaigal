using AutoMapper;
using Domain.Models;
using Domain.Modules.Suppliers.DTO;
using Domain.Modules.Suppliers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SupplierDto>> GetAllAsync()
        {
            var suppliers = await _repository.GetAllAsync();
            return _mapper.Map<List<SupplierDto>>(suppliers);
        }

        public async Task<SupplierDto> GetByIdAsync(Guid id)
        {
            var supplier = await _repository.GetByIdAsync(id);

            if (supplier == null)
                throw new KeyNotFoundException("Supplier not found");

            return _mapper.Map<SupplierDto>(supplier);
        }

        public async Task<SupplierDto> CreateAsync(CreateSupplierDto dto)
        {
            var supplier = _mapper.Map<Supplier>(dto);

            supplier.Id = Guid.NewGuid();
            supplier.CreatedAt = DateTime.UtcNow;
            supplier.IsActive = true;

            await _repository.AddAsync(supplier);
            await _repository.SaveAsync();

            return _mapper.Map<SupplierDto>(supplier);
        }

        public async Task<SupplierDto> UpdateAsync(Guid id, UpdateSupplierDto dto)
        {
            var supplier = await _repository.GetByIdAsync(id);

            if (supplier == null)
                throw new KeyNotFoundException("Supplier not found");

            _mapper.Map(dto, supplier); // updates existing entity

            await _repository.SaveAsync();

            return _mapper.Map<SupplierDto>(supplier);
        }

        public async Task<SupplierDto> DeleteAsync(Guid id)
        {
            var supplier = await _repository.GetByIdAsync(id);

            if (supplier == null)
                throw new KeyNotFoundException("Supplier not found");

            supplier.IsActive = false; // Soft delete

            await _repository.SaveAsync();

            return _mapper.Map<SupplierDto>(supplier);
        }
    }
}
