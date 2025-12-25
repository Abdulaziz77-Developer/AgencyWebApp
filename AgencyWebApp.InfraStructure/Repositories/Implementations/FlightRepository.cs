using AgencyWebApp.Application.DTOs.FlightDto;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AgencyWebApp.Infrastructure.Data;

namespace AgencyWebApp.Infrastructure.Repositories.Implementations
{
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(AppDbContext context) : base(context) { }
    }

}
