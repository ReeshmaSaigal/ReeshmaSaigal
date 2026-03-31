using System.ComponentModel.DataAnnotations;

namespace ConsultantMVCApp.DTO
{
    public class LoginDto
    {
        public string UserName { get; set; }

        [Required, MaxLength(200)]
        public string Password { get; set; }
    }
}
