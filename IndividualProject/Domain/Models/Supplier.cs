using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }

        [Required, MaxLength(150)]
        public string SupplierName { get; set; } = null!;

        [Required, MaxLength(15)]
        public string Phone { get; set; } = null!;

        [MaxLength(150)]
        public string? Email { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }

        public ICollection<Purchase>? Purchases { get; set; }
       

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
