using AgencyWebApp.Application.DTOs.HotelDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgencyWebApp.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _hotelService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hotel = await _hotelService.GetByIdAsync(id);
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHotelDto dto)
        {
            var created = await _hotelService.CreateAsync(dto);
            return Ok(created);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHotelDto dto)
        {
            var updated = await _hotelService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _hotelService.DeleteAsync(id);
            return NoContent();
        }
    }
}
