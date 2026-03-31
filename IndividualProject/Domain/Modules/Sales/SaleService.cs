using AutoMapper;
using Domain.Models;
using Domain.Modules.Sales.DTO;
using Domain.Modules.Sales.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Sales
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SaleDto> CreateSaleAsync(SaleDto dto)
        {
            var sale = _mapper.Map<Sale>(dto);

            sale.TotalAmount = sale.Items!.Sum(
                i => i.Quantity * i.SellingPrice);

            var result = await _repository.AddAsync(sale);
            return _mapper.Map<SaleDto>(result);
        }

        public async Task<List<SaleDto>> GetSalesAsync()
        {
            var sales = await _repository.GetAllAsync();
            return _mapper.Map<List<SaleDto>>(sales);
        }

        public async Task<SaleDto?> GetSaleByIdAsync(Guid id)
        {
            var sale = await _repository.GetByIdAsync(id);
            return sale == null ? null : _mapper.Map<SaleDto>(sale);
        }

        public async Task<List<SaleDto>> GetSalesByCustomerAsync(string customerName)
        {
            var sales = await _repository.GetByCustomerAsync(customerName);
            return _mapper.Map<List<SaleDto>>(sales);
        }
    }
}
