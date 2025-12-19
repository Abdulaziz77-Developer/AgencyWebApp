namespace AgencyWebApp.API.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public string Description { get; set; } = "";

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public List<Tour> Tours { get; set; } = [];
        public List<Review> Reviews { get; set; } = [];
        public List<Booking> Bookings { get; set; } = [];
    }
}
