using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Purchase
    {
        public Guid Id { get; set; }

        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }

        [Required, MaxLength(50)]
        public string Status { get; set; } = null!;

        public ICollection<PurchaseItem>? Items { get; set; }
    }
}
