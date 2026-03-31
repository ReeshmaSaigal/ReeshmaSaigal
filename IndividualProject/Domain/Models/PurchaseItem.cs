using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PurchaseItem
    {
        public Guid Id { get; set; }

        public Guid PurchaseId { get; set; }
        public Purchase Purchase { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal CostPrice { get; set; }
    }

}
