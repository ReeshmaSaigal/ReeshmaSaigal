using System.ComponentModel.DataAnnotations;
using System;

namespace HireMeNow_WebApi.API.JobProvider.RequestObjects
{
    public class companyUserRequest
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public string Password { get; set; }

    }
}
