namespace AgencyWebApp.Application.DTOs.BookingDTOs
{
    public class UpdateBookingDto
    {
        public bool Status { get; set; } = false;
        public int? TourId { get; set; }
        public int? HotelId { get; set; }
        public int? FlightId { get; set; }
    }
}
