using AgencyWebApp.Application.DTOs.MapDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgencyWebApp.API.Controllers
{
    [ApiController]
    [Route("api/map")]
    public class MapController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ITourService _tourService;
        private readonly IFlightService _flightService;

        public MapController(
            IHotelService hotelService,
            ITourService tourService,
            IFlightService flightService)
        {
            _hotelService = hotelService;
            _tourService = tourService;
            _flightService = flightService;
        }

        [HttpGet("hotels")]
        public async Task<ActionResult<List<HotelMapDto>>> GetHotels()
        {
            return Ok(await _hotelService.GetHotelsForMapAsync());
        }

        [HttpGet("tours")]
        public async Task<ActionResult<List<TourMapDto>>> GetTours()
        {
            return Ok(await _tourService.GetToursForMapAsync());
        }

        [HttpGet("flights")]
        public async Task<ActionResult<List<FlightMapDto>>> GetFlights()
        {
            return Ok(await _flightService.GetFlightsForMapAsync());
        }
    }
}

