namespace AgencyWebApp.API.DTOs.TourDTOs
{
    public class UpdateTourDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Region { get; set; }
        public string? PhotoUrl { get; set; }
        public int? HotelId { get; set; }
        public decimal? StartLatitude { get; set; }
        public decimal? StartLongitude { get; set; }
    }
}
