using AgencyWebApp.API.DTOs.ReviewDTOs;
using AgencyWebApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyWebApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _reviewService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null) return NotFound();
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewDto dto)
        {
            var created = await _reviewService.CreateAsync(dto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReviewDto dto)
        {
            var updated = await _reviewService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewService.DeleteAsync(id);
            return NoContent();
        }
    }

}
