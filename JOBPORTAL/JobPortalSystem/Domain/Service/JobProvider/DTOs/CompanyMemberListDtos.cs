using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.Dtos
{
	public  class CompanyMemberListDtos
	{
		public string FirstName { get; set; } = null!;
		public string? LastName { get; set; }
		
		public Enums.Role Role { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; } = null!;
		public string Phone { get; set; } = null!;
		//public virtual JobProviderCompany? CompanyNavigation { get; set; }

	}
}
