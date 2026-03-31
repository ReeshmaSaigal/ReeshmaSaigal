using Domain.Modules.Sales.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Sales.Interface
{
    public interface ISaleService
    {
        Task<SaleDto> CreateSaleAsync(SaleDto dto);
        Task<List<SaleDto>> GetSalesAsync();
        Task<SaleDto?> GetSaleByIdAsync(Guid id);
        Task<List<SaleDto>> GetSalesByCustomerAsync(string customerName);
    }
}
