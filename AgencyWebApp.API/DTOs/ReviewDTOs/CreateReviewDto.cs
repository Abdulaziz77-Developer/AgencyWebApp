namespace AgencyWebApp.API.DTOs.ReviewDTOs
{
    public class CreateReviewDto
    {
        public string Text { get; set; } = "";
        public int UserId { get; set; }
        public int? TourId { get; set; }
        public int? HotelId { get; set; }
        public int? FlightId { get; set; }
    }
}
