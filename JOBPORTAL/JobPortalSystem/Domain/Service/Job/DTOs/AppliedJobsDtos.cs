using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.DTOs
{
	public class AppliedJobsDtos
	{
		public AppliedJobsDtos()
		{
		}

		public AppliedJobsDtos(Guid id, string title)
		{
			Id = id;
			JobPostJobTitle = title;
		}

		public Guid Id { get; set; }
		public string JobPostJobTitle { get; set; }
		public string JobPostJobSummary { get; set; }
		public string JobPostCompanyLegalName { get;set; }





	}
}
