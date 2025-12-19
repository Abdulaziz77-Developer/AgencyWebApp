namespace AgencyWebApp.API.DTOs.FlightDto
{
    public class UpdateFlightDto
    {
        public string? AirPlaneName { get; set; }
        public int? FlightNumber { get; set; }
        public string? FromCity { get; set; }
        public string? ToCity { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public decimal? FromLatitude { get; set; }
        public decimal? FromLongitude { get; set; }
        public decimal? ToLatitude { get; set; }
        public decimal? ToLongitude { get; set; }
    }
}
