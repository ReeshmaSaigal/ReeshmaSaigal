using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Suppliers.DTO
{
    public class CreateSupplierDto
    {
        public string SupplierName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
    }
}
