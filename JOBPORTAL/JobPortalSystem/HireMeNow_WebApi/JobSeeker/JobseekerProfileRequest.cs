namespace HireMeNow_WebApi.JobSeeker
{
    public class JobseekerProfileRequest
    {
       
        public Guid JobSeekerId { get; set; }

        public string? ProfileName { get; set; }

        public string? ProfileSummary { get; set; }
    }
}
