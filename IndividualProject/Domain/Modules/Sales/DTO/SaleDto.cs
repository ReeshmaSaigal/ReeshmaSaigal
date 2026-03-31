using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Sales.DTO
{
    public class SaleDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<SaleItemDto> Items { get; set; } = new();
    }
}
