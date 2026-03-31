using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TourBookingMVCApplication.Enum;
namespace TourBookingMVCApplication.Models
{
    public class TourBookingForm
    { 
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid TourId { get; set; }
        public Guid? UserId { get; set; }

        public string FirstName { get; set; } 
        public string LastName { get; set; } 

        public string? Gender { get; set; }
        public DateOnly? Dob { get; set; }
        public string? Citizenship { get; set; }
        public string? PassportNumber { get; set; }

        public DateOnly? IssueDate { get; set; }
        public DateOnly? ExpiryDate { get; set; }

        public string? PlaceOfBirth { get; set; }
        public bool? LeadPassenger { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ParticipantType ParticipantType { get; set; }
        public TourStatus Status { get; set; }
        public virtual ICollection<ParticipantInformation> ParticipantInformations { get; set; } = new List<ParticipantInformation>();

        public virtual Tour Tour { get; set; }
        public virtual AuthUser? User { get; set; }
    }
}

