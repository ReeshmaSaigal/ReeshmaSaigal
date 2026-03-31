using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.DTOs
{
    public class BranchDto
    {
        public string BranchName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public string Branchcode { get; set; } = string.Empty;
    }
}
