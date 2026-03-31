using TourBookingMVCApplication.Models;

namespace TourBookingMVCApplication.DTO
{
    public class TourDetailsDto
    {
        public TourDto Tour{ get; set; }
        public TourBookingDto Booking { get; set; }
    }
}
