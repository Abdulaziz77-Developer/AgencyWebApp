using AgencyWebApp.Domain.Enums;

namespace AgencyWebApp.Application.DTOs.UserDTOs;
    public class UpdateUserDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Role? Role { get; set; }
        public decimal? HomeLatitude { get; set; }
        public decimal? HomeLongitude { get; set; }
    }

