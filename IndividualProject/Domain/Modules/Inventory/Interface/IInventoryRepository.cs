using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Inventory.Interface
{
    public interface IInventoryRepository
    {
        Task<InventoryLog?> GetByProductIdAsync(Guid productId);
        Task<List<InventoryLog>> GetAllAsync();
        Task AddAsync(InventoryLog inventory);
        Task UpdateAsync(InventoryLog inventory);
    }
}
