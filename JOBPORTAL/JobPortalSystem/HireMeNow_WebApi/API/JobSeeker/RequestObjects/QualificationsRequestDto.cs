namespace HireMeNow_WebApi.API.JobSeeker.RequestObjects
{
    public class QualificationsRequestDto
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Guid? JobseekerProfileId { get; set; }

      
    }
}
