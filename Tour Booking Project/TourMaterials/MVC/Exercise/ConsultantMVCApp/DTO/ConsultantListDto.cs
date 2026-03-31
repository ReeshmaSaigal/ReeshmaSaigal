namespace ConsultantMVCApp.DTO
{
    public class ConsultantListDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Username { get; set; } = null!;
        public int AssignedTours { get; set; }
        public int Bookings { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
