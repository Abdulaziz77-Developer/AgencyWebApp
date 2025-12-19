namespace AgencyWebApp.API.DTOs.MapDTOs
{
    public class TourMapDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
    }
}
