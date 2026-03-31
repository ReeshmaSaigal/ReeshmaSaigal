using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Purchases.Interface
{
    public interface IPurchaseRepository
    {
        Task<Purchase> AddAsync(Purchase purchase);
        Task<List<Purchase>> GetAllAsync();
        Task<Purchase?> GetByIdAsync(Guid id);
        Task UpdateAsync(Purchase purchase);
    }
}
