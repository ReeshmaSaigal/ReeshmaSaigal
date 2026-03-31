using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<StockTransaction>? StockTransactions { get; set; }
    }
}
