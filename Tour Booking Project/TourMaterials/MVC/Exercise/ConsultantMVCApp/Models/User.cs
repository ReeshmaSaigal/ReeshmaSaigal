using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsultantMVCApp.Enum;
using Microsoft.EntityFrameworkCore;

namespace ConsultantMVCApp.Models;

public partial class User
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(10)]
    public string Gender { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public UserRole Role { get; set; }

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string TelephoneNo { get; set; } = null!;

    [StringLength(200)]
    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<TourBookingForm> TourBookingForms { get; set; } = new List<TourBookingForm>();

    [InverseProperty("Consultant")]
    public virtual ICollection<Tour> TourConsultants { get; set; } = new List<Tour>();

    [InverseProperty("Customer")]
    public virtual ICollection<Tour> TourCustomers { get; set; } = new List<Tour>();
}
