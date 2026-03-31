using System.ComponentModel.DataAnnotations;

namespace HireMeNow_WebApi.API.JobProvider.RequestObjects
{
    public class JobProviderSignupRequest
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
    }
}
