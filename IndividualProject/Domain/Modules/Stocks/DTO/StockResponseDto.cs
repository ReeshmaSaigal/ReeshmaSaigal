using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Stocks.DTO
{
    public class StockResponseDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
    }
}
