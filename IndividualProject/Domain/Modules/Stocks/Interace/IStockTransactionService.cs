using Domain.Modules.Stocks.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Stocks.Interace
{
    public interface IStockTransactionService
    {
        Task<StockResponseDto> StockInAsync(CreateStockDto dto);
        Task<StockResponseDto> StockOutAsync(CreateStockDto dto);

        Task<List<StockResponseDto>> GetStockInHistoryAsync();
        Task<List<StockResponseDto>> GetStockOutHistoryAsync();

        Task<StockResponseDto> GetByIdAsync(Guid id);
    }
}
