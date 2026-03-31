using Domain.Models;
using Domain.Modules.Stocks.Interace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Modules.Stocks
{
    public class StockTransactionRepository : IStockTransactionRepository
    {
        private readonly SmartStockDbContext _context;

        public StockTransactionRepository(SmartStockDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StockTransaction stock)
        {
            await _context.StockTransactions.AddAsync(stock);
        }

        public async Task<StockTransaction?> GetByIdAsync(Guid id)
        {
            return await _context.StockTransactions
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<StockTransaction>> GetByTypeAsync(string type)
        {
            return await _context.StockTransactions
                .Where(x => x.Type == type)
                .OrderByDescending(x => x.TransactionDate)
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}