using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Branch
    {
        [Key]
        public Guid BranchId { get; set; }
        public string BranchName { get; set; }=string.Empty;
        public string Location { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public  string BranchCode { get; set; } = string.Empty;
        public virtual  ICollection<Batch> Batches { get; set; } = new List<Batch>();
        public virtual ICollection<StudentProfile> StudentProfiles { get; set; } = new List<StudentProfile>();

    }
}
