using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Products.DTO
{
    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }

    }
}
