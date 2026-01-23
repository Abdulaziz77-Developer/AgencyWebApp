namespace AgencyWebApp.Application.DTOs.BookingDTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public int? TourId { get; set; }
        public int? HotelId { get; set; }
        public int? FlightId { get; set; }
    }
}
