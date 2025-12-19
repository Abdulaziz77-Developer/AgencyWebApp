namespace AgencyWebApp.API.DTOs.BookingDTOs
{
    public class UpdateBookingDto
    {
        public int? TourId { get; set; }
        public int? HotelId { get; set; }
        public int? FlightId { get; set; }
    }
}
