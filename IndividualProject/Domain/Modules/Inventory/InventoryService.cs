using AutoMapper;
using Domain.Models;
using Domain.Modules.Inventory.DTO;
using Domain.Modules.Inventory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Inventory
{
    public class InventoryService: IInventoryService
    {
        private readonly IInventoryRepository _repository;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<InventoryDto>> GetAllAsync()
        {
            var inventory = await _repository.GetAllAsync();
            return _mapper.Map<List<InventoryDto>>(inventory);
        }

        public async Task<InventoryDto> GetByProductIdAsync(Guid productId)
        {
            var inventory = await _repository.GetByProductIdAsync(productId)
                ?? throw new Exception("Product inventory not found");

            return _mapper.Map<InventoryDto>(inventory);
        }

        public async Task<InventoryDto> UpdateStockAsync(Guid productId, int quantity, string type)
        {
            var inventory = await _repository.GetByProductIdAsync(productId);

            if (inventory == null)
            {
                inventory = new InventoryLog
                {
                    ProductId = productId,
                    CurrentQuantity = 0
                };

                await _repository.AddAsync(inventory);
            }

            if (type == "IN")
                inventory.CurrentQuantity += quantity;
            else if (type == "OUT")
                inventory.CurrentQuantity -= quantity;
            else
                throw new Exception("Invalid stock type");

            inventory.LastUpdated = DateTime.UtcNow;

            await _repository.UpdateAsync(inventory);

            return _mapper.Map<InventoryDto>(inventory);
        }

        Task<List<InventoryDto>> IInventoryService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<InventoryDto> IInventoryService.GetByProductIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        Task<InventoryDto> IInventoryService.UpdateStockAsync(Guid productId, int quantity, string type)
        {
            throw new NotImplementedException();
        }
    }
}
