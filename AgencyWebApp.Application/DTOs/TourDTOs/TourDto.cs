namespace AgencyWebApp.Application.DTOs.TourDTOs
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string Region { get; set; } = "";
        public string PhotoUrl { get; set; } = "";
        public int Duration { get; set; } // Duration in days
        public int Rating { get; set; }
        public bool Status { get; set; }
        public int HotelId { get; set; }
        public decimal StartLatitude { get; set; }
        public decimal StartLongitude { get; set; }
        public List<TourPointDto> TourPoints { get; set; } = [];
    }
}
