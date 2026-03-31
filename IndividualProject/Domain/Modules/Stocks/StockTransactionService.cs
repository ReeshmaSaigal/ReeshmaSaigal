using AutoMapper;
using Domain.Models;
using Domain.Modules.Stocks.DTO;
using Domain.Modules.Stocks.Interace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Stocks
{
    public class StockTransactionService : IStockTransactionService
    {
        private readonly IStockTransactionRepository _repository;
        private readonly IMapper _mapper;

        public StockTransactionService(
            IStockTransactionRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StockResponseDto> StockInAsync(CreateStockDto dto)
        {
            var stock = new StockTransaction
            {
                Id = Guid.NewGuid(),
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Type = "IN",
                TransactionDate = DateTime.UtcNow
            };

            await _repository.AddAsync(stock);
            await _repository.SaveAsync();

            return _mapper.Map<StockResponseDto>(stock);
        }

        public async Task<StockResponseDto> StockOutAsync(CreateStockDto dto)
        {
            var stock = new StockTransaction
            {
                Id = Guid.NewGuid(),
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Type = "OUT",
                TransactionDate = DateTime.UtcNow
            };

            await _repository.AddAsync(stock);
            await _repository.SaveAsync();

            return _mapper.Map<StockResponseDto>(stock);
        }

        public async Task<List<StockResponseDto>> GetStockInHistoryAsync()
        {
            var list = await _repository.GetByTypeAsync("IN");
            return _mapper.Map<List<StockResponseDto>>(list);
        }

        public async Task<List<StockResponseDto>> GetStockOutHistoryAsync()
        {
            var list = await _repository.GetByTypeAsync("OUT");
            return _mapper.Map<List<StockResponseDto>>(list);
        }

        public async Task<StockResponseDto> GetByIdAsync(Guid id)
        {
            var stock = await _repository.GetByIdAsync(id);

            if (stock == null)
                throw new KeyNotFoundException("Stock transaction not found");

            return _mapper.Map<StockResponseDto>(stock);
        }
    }
}
