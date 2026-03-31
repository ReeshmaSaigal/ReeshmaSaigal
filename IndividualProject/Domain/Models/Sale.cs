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
    public class Sale
    {
        public Guid Id { get; set; }

        [Required, MaxLength(150)]
        public string CustomerName { get; set; } = null!;

        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }

        public ICollection<SaleItem>? Items { get; set; }
    }
}
