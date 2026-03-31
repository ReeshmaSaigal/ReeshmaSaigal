using Domain.Models;

namespace HireMeNow_WebApi.API.JobSeeker.RequestObjects
{
	public class ApplyJobRequest
	{

		
		public Guid JobPost_id { get; set; }
		public Guid Applicant { get; set; }
		public Guid Resume_id { get; set; }
		public string CoverLetter { get; set; }

	}
}
