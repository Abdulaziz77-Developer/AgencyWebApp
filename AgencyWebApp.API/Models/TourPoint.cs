
namespace AgencyWebApp.API.Models
{
    public class TourPoint
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Order { get; set; } 
    }
}
