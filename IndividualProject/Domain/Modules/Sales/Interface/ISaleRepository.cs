using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Sales.Interface
{
    public interface ISaleRepository
    {
        Task<Sale> AddAsync(Sale sale);
        Task<List<Sale>> GetAllAsync();
        Task<Sale?> GetByIdAsync(Guid id);
        Task<List<Sale>> GetByCustomerAsync(string customerName);
    }
}
