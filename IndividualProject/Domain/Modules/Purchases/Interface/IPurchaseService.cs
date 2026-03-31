using Domain.Modules.Purchases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Purchases.Interface
{
    public interface IPurchaseService
    {
        Task<PurchaseDto> CreatePurchaseAsync(PurchaseDto dto);
        Task<List<PurchaseDto>> GetPurchasesAsync();
        Task<PurchaseDto?> GetPurchaseByIdAsync(Guid id);
        Task<bool> UpdatePurchaseStatusAsync(Guid id, string status);
    }
}
