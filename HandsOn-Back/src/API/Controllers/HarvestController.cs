using Microsoft.AspNetCore.Authorization;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.InputModels.HarvestModels;

namespace API.Controllers
{
    [ApiController]
    [Route("api/harvest")]
    [Authorize]
    public class HarvestController(IHarvestServices harvestServices) : ControllerBase
    {
        private readonly IHarvestServices _harvestServices = harvestServices;

        [HttpGet]
        public async Task<IActionResult> GetAllByFarmIdAsync(Guid farmId)
        {
            var harvests = await _harvestServices.GetAllByFarmIdAsync(farmId);
            return Ok(harvests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var harvest = await _harvestServices.GetByIdAsync(id);
            return Ok(harvest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateHarvestInputModel inputModel)
        {
            var harvest = await _harvestServices.CreateAsync(inputModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = harvest.Id }, harvest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateHarvestInputModel inputModel)
        {
            var harvest = await _harvestServices.UpdateAsync(id, inputModel);
            return harvest is not null ? Ok(harvest) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var harvest = await _harvestServices.DeleteAsync(id);
            return harvest is not null ? NoContent() : NotFound();
        }
    }
} 