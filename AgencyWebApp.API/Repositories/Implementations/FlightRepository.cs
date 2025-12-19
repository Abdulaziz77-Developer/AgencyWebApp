using AgencyWebApp.API.Data;
using AgencyWebApp.API.DTOs.FlightDto;
using AgencyWebApp.API.Models;
using AgencyWebApp.API.Repositories.Interfaces;

namespace AgencyWebApp.API.Repositories.Implementations
{
    public class FlightRepository : BaseRepository<Flight, UpdateFlightDto>, IFlightRepository
    {
        public FlightRepository(AppDbContext context) : base(context) { }
    }

}
