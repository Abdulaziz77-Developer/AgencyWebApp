using AgencyWebApp.API.Enums;
using System.Data;

namespace AgencyWebApp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public Role Role { get; set; } = Role.User;

        public decimal? HomeLatitude { get; set; }
        public decimal? HomeLongitude { get; set; }

        public List<Review> Reviews { get; set; } = [];
        public List<Booking> Bookings { get; set; } = [];
    }
}
