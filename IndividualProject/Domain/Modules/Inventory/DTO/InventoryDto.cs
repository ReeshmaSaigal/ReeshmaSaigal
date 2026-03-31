using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Inventory.DTO
{
    public class InventoryDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int CurrentQuantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
