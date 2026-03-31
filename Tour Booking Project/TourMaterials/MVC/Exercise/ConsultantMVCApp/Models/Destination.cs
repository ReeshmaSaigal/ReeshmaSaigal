using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsultantMVCApp.Models;

public partial class Destination
{
    [Key]
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? City { get; set; }

    public string? ImageUrl { get; set; }

    [InverseProperty("Destination")]
    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
