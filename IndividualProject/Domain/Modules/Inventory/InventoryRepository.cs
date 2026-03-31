using Domain.Models;
using Domain.Modules.Inventory.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Inventory
{
    //public class InventoryRepository : IInventoryRepository
    //{
    //    private readonly SmartStockDbContext _context;

    //    public InventoryRepository(SmartStockDbContext context)
    //    {
    //        _context = context;
    //    }

        //public async Task<InventoryLog?> GetByProductIdAsync(Guid productId)
        //{
        //    return await _context
        //        .Include(x => x.Product)
        //        .FirstOrDefaultAsync(x => x.ProductId == productId);
        //}

        //public async Task<List<InventoryLog>> GetAllAsync()
        //{
        //    return await _context.InventoryLogs
        //        .Include(x => x.Product)
        //        .ToListAsync();
        //}

        //public async Task AddAsync(InventoryLog inventory)
        //{
        //    _context.InventoryLogs.Add(inventory);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(InventoryLog inventory)
        //{
        //    _context.InventoryLogs.Update(inventory);
        //    await _context.SaveChangesAsync();
        //}

    //    public Task<InventoryLog?> GetByProductIdAsync(Guid productId)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}