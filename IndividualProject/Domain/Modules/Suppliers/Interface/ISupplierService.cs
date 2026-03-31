using Domain.Modules.Suppliers.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Suppliers.Interface
{
    public interface ISupplierService
    {
        Task<List<SupplierDto>> GetAllAsync();
        Task<SupplierDto> GetByIdAsync(Guid id);
        Task<SupplierDto> CreateAsync(CreateSupplierDto request);
        Task<SupplierDto> UpdateAsync(Guid id, UpdateSupplierDto request);
        Task<SupplierDto> DeleteAsync(Guid id);
    }
}
