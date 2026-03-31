
namespace TourBookingMVCApplication.Models
{
    public class Destination
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }

       
        public string? ImageUrl { get; set; }

        public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
    }
}
