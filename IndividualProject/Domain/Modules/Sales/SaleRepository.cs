using Domain.Models;
using Domain.Modules.Sales.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Modules.Sales
{
    public class SaleRepository : ISaleRepository
{
    private readonly SmartStockDbContext _context;

        public SaleRepository(SmartStockDbContext context)
        {
            _context = context;
        }

        public async Task<Sale> AddAsync(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await _context.Sales
                .Include(s => s.Items)
                .ToListAsync();
        }

        public async Task<Sale?> GetByIdAsync(Guid id)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Sale>> GetByCustomerAsync(string customerName)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .Where(s => s.CustomerName == customerName)
                .ToListAsync();
        }
    }
}

