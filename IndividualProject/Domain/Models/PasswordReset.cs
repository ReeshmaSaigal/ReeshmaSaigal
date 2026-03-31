using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PasswordReset
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        public string Token { get; set; }

        public DateTime ExpiryTime { get; set; }

        public bool IsUsed { get; set; } = false;
    }
}
