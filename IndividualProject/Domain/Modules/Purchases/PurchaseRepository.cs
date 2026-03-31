using Domain.Models;
using Domain.Modules.Purchases.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Modules.Purchases
{
    public class PurchaseRepository: IPurchaseRepository
{
    private readonly SmartStockDbContext _context;

        public PurchaseRepository(SmartStockDbContext context)
        {
            _context = context;
        }

        public async Task<Purchase> AddAsync(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
            return purchase;
        }

        public async Task<List<Purchase>> GetAllAsync()
        {
            return await _context.Purchases
                .Include(p => p.Items)
                .ToListAsync();
        }

        public async Task<Purchase?> GetByIdAsync(Guid id)
        {
            return await _context.Purchases
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
            await _context.SaveChangesAsync();
        }
    }
}

