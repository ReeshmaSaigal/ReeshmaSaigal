using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Admin.DTOs
{
    public class CompanyUsersDto
    {
        public Guid Id { get; set; }
        public Guid? Company { get; set; }
    }
}
