using System.ComponentModel.DataAnnotations;

namespace TourBookingMVCApplication.DTO
{
    public class LoginDto
    {
        public string UserName { get; set; }

        [Required, MaxLength(200)]
        public string Password { get; set; }
    }
}
