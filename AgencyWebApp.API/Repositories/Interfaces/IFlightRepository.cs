using AgencyWebApp.API.DTOs.FlightDto;
using AgencyWebApp.API.Models;

namespace AgencyWebApp.API.Repositories.Interfaces
{
    public interface IFlightRepository : IBaseRepository<Flight, UpdateFlightDto>
    {
    }
}
