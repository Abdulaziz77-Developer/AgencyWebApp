namespace AgencyWebApp.Application.DTOs.ReviewDTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int? TourId { get; set; }
        public int? HotelId { get; set; }
        public int? FlightId { get; set; }
    }
}
