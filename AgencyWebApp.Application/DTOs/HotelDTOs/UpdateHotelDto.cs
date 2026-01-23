namespace AgencyWebApp.Application.DTOs.HotelDTOs
{
    public class UpdateHotelDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal Price  { get; set; }
        public string? PhotoUrl { get; set; }
       
        public bool Status { get; set; }
    }
}
