using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class InventoryLog
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int CurrentQuantity { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public Product Product { get; set; } = null!;
    }
}
