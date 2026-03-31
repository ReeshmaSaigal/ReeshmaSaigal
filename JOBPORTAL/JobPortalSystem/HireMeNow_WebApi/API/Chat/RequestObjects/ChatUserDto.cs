using System.ComponentModel.DataAnnotations;
using System;

namespace HireMeNow_WebApi.API.Chat.RequestObjects
{
    public class ChatUserDto
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Domain.Enums.Role? Role { get; set; }
    }
}
