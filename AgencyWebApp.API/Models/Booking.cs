namespace AgencyWebApp.API.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int? TourId { get; set; }
        public Tour? Tour { get; set; }

        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public int? FlightId { get; set; }
        public Flight? Flight { get; set; }
    }
}
