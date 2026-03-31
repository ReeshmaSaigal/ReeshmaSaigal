namespace TourDestinationMVCApp.DTO
{
    public class DestinationResponseDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        //public byte[]? ImageData { get; set; }
        public string? ImageUrl { get; set; }
    }
}
