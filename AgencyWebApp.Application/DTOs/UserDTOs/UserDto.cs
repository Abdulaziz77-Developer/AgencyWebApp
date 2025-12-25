using AgencyWebApp.Domain.Enums;

namespace AgencyWebApp.Application.DTOs.UserDTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public Role Role { get; set; }
        public decimal? HomeLatitude { get; set; }
        public decimal? HomeLongitude { get; set; }
    }
}
