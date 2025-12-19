using AgencyWebApp.API.DTOs.FlightDto;
using AgencyWebApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyWebApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightsService;

        public FlightsController(IFlightService flightsService)
        {
            _flightsService = flightsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _flightsService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var flight = await _flightsService.GetByIdAsync(id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFlightDto dto)
        {
            var created = await _flightsService.CreateAsync(dto);
            return Ok(created);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateFlightDto dto)
        {
            var updated = await _flightsService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _flightsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
