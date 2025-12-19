namespace AgencyWebApp.API.DTOs.MapDTOs
{
    public class FlightMapDto
    {
        public int Id { get; set; }
        public double FromLatitude { get; set; }
        public double FromLongitude { get; set; }
        public double ToLatitude { get; set; }
        public double ToLongitude { get; set; }
    }
}
