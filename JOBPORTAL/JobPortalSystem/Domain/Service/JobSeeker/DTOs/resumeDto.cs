using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobSeeker.DTOs
{
	public class resumeDto
	{
		public Guid Id { get; set; }

		public string? Title { get; set; }

		public byte[]? File { get; set; }
	}
}
