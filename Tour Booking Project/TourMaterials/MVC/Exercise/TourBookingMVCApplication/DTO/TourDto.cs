namespace TourBookingMVCApplication.DTO
{
    public class TourDto
    {public Guid Id { get; set; }
        public string TourName { get; set; }
        public string TourDescription { get; set; }
        public string Destination { get; set; }
        public DateOnly DepartureDate { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public string NoOfNights { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
