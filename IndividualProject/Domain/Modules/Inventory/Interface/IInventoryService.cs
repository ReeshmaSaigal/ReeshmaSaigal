using System;
using System.Collections.Generic;
using Domain.Modules.Inventory.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Inventory.Interface
{
    public interface IInventoryService
    {
        Task<List<InventoryDto>> GetAllAsync();
        Task<InventoryDto> GetByProductIdAsync(Guid productId);
        Task<InventoryDto> UpdateStockAsync(Guid productId, int quantity, string type);
    }
}
