using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Suppliers.Interface
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(Guid id);
        Task AddAsync(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(Supplier supplier);
        Task<bool> SaveAsync();
    }
}
