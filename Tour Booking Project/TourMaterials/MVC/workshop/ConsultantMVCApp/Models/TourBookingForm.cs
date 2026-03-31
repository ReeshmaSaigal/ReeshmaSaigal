using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsultantMVCApp.Models;

[Index("TourId", Name = "IX_TourBookingForms_TourId")]
[Index("UserId", Name = "IX_TourBookingForms_UserId")]
public partial class TourBookingForm
{
    [Key]
    public Guid Id { get; set; }

    public Guid TourId { get; set; }

    public Guid? UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Citizenship { get; set; }

    public string? PassportNumber { get; set; }

    public DateOnly? IssueDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public string? PlaceOfBirth { get; set; }

    public bool? LeadPassenger { get; set; }

    public DateTime CreatedAt { get; set; }

    public int ParticipantType { get; set; }

    public int Status { get; set; }

    [InverseProperty("Lead")]
    public virtual ICollection<ParticipantInformation> ParticipantInformations { get; set; } = new List<ParticipantInformation>();

    [ForeignKey("TourId")]
    [InverseProperty("TourBookingForms")]
    public virtual Tour Tour { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("TourBookingForms")]
    public virtual User? User { get; set; }
}
