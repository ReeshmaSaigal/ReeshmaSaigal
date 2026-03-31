using AutoMapper;
using Domain.Models;
using Domain.Modules.Products.DTO;
using Domain.Modules.Products.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto?> GetByIdAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductResponseDto>(product);
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Product not found");

            _mapper.Map(dto, product);
            await _repository.UpdateAsync(product);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Product not found");

            await _repository.DeleteAsync(product);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<ProductResponseDto>> SearchAsync(string keyword)
        {
            var products = await _repository.SearchAsync(keyword);
            return _mapper.Map<List<ProductResponseDto>>(products);
        }

        public async Task ToggleStatusAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Product not found");

            product.IsActive = !product.IsActive;
            await _repository.SaveChangesAsync();
        }
    }
}
