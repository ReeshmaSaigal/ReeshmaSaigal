using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.DTOs
{
    public class CompanyMemberDtos
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public Enums.Role Role { get; set; } = Enums.Role.COMPANY_USER;
        public string? UserName { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public Guid? Company { get; set; }

        public string Password { get; set; }


    }
}
