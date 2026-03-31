using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Suppliers.DTO
{
    public class SupplierDto
    {
        public Guid Id { get; set; }
        public string SupplierName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }
}
