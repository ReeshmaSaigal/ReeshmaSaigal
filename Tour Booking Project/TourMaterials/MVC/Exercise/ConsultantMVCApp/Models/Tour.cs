using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsultantMVCApp.Models;

[Index("ConsultantId", Name = "IX_Tours_ConsultantId")]
[Index("CustomerId", Name = "IX_Tours_CustomerId")]
[Index("DestinationId", Name = "IX_Tours_DestinationId")]
public partial class Tour
{
    [Key]
    public Guid Id { get; set; }

    public string TourName { get; set; } = null!;

    public string? TourDescription { get; set; }

    public Guid DestinationId { get; set; }

    public int? NoOfNights { get; set; }

    public int Price { get; set; }

    public DateOnly? DepartureDate { get; set; }

    public DateOnly? ArrivalDate { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid ConsultantId { get; set; }

    public int Status { get; set; }

    [ForeignKey("ConsultantId")]
    [InverseProperty("TourConsultants")]
    public virtual User Consultant { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("TourCustomers")]
    public virtual User? Customer { get; set; }

    [ForeignKey("DestinationId")]
    [InverseProperty("Tours")]
    public virtual Destination Destination { get; set; } = null!;

    [InverseProperty("Tour")]
    public virtual ICollection<TourBookingForm> TourBookingForms { get; set; } = new List<TourBookingForm>();
}
