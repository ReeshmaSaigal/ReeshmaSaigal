using AutoMapper;
using Domain.Models;
using Domain.Modules.Purchases.DTO;
using Domain.Modules.Purchases.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Purchases
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public PurchaseService(IPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PurchaseDto> CreatePurchaseAsync(PurchaseDto dto)
        {
            var purchase = _mapper.Map<Purchase>(dto);

            purchase.TotalAmount = purchase.Items!.Sum(
                i => i.Quantity * i.CostPrice);

            purchase.Status = "CREATED";

            var result = await _repository.AddAsync(purchase);
            return _mapper.Map<PurchaseDto>(result);
        }

        public async Task<List<PurchaseDto>> GetPurchasesAsync()
        {
            var purchases = await _repository.GetAllAsync();
            return _mapper.Map<List<PurchaseDto>>(purchases);
        }

        public async Task<PurchaseDto?> GetPurchaseByIdAsync(Guid id)
        {
            var purchase = await _repository.GetByIdAsync(id);
            return purchase == null ? null : _mapper.Map<PurchaseDto>(purchase);
        }

        public async Task<bool> UpdatePurchaseStatusAsync(Guid id, string status)
        {
            var purchase = await _repository.GetByIdAsync(id);
            if (purchase == null) return false;

            purchase.Status = status;
            await _repository.UpdateAsync(purchase);
            return true;
        }
    }
}
