namespace HireMeNow_WebApi.API.Job.SavedJobObjects
{
	public class SaveJobRequest
	{
		public Guid SavedBy { get; set; }
		public Guid Job { get; set; }
		public DateTime DateSaved { get; set; }
	}
}
