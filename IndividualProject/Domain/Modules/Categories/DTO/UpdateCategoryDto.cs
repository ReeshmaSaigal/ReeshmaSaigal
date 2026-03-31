using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Categories.DTO
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
