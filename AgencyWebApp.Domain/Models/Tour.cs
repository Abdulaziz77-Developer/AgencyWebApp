namespace AgencyWebApp.Domain.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string Region { get; set; } = "";
        public string PhotoUrl { get; set; } = "";
        public int Duration { get; set; }
        public int Rating { get; set; }
        public bool Status { get; set; }

        public decimal StartLatitude { get; set; }
        public decimal StartLongitude { get; set; }

        public List<TourPoint> TourPoints { get; set; } = [];
        public List<Review> Reviews { get; set; } = [];
        public List<Booking> Bookings { get; set; } = [];
    }
}
