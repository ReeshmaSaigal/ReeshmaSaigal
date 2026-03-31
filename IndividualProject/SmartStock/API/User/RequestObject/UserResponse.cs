using Domain.Enums;

namespace SmartStock.API.User.RequestObject
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; } 
    }
}
