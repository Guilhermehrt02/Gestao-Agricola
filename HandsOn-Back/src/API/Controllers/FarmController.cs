using Microsoft.AspNetCore.Authorization;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.InputModels.FarmModels;

namespace API.Controllers
{
    [ApiController]
    [Route("api/farm")]
    [Authorize]
    public class FarmController(IFarmServices farmServices) : ControllerBase
    {
        private readonly IFarmServices _farmServices = farmServices;

        [HttpGet]
        public async Task<IActionResult> GetAllByUserIdAsync(Guid userId)
        {
            var farms = await _farmServices.GetAllByUserIdAsync(userId);
            return Ok(farms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var farm = await _farmServices.GetByIdAsync(id);
            return Ok(farm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateFarmInputModel inputModel)
        {
            var farm = await _farmServices.CreateAsync(inputModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = farm.Id }, farm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateFarmInputModel inputModel)
        {
            var farm = await _farmServices.UpdateAsync(id, inputModel);
            return farm is not null ? Ok(farm) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var farm = await _farmServices.DeleteAsync(id);
            return farm is not null ? NoContent() : NotFound();
        }
    }
}