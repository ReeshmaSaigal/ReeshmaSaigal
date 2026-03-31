using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Stocks.Interace
{
    public interface IStockTransactionRepository
    {
        Task AddAsync(StockTransaction stock);
        Task<StockTransaction?> GetByIdAsync(Guid id);
        Task<List<StockTransaction>> GetByTypeAsync(string type);
        Task SaveAsync();
    }
}
