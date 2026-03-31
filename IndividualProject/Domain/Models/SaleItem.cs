using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SaleItem
    {
        public Guid Id { get; set; }

        public Guid SaleId { get; set; }
        public Sale Sale { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal SellingPrice { get; set; }
    }
}
