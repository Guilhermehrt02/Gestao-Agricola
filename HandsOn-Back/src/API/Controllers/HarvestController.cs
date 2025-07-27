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

        [HttpGet("farm/{farmId}")]
        public async Task<IActionResult> GetAllByFarmId(Guid farmId)
        {
            var harvests = await _harvestServices.GetAllByFarmIdAsync(farmId);
            return Ok(harvests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var harvest = await _harvestServices.GetByIdAsync(id);
            return Ok(harvest);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHarvestInputModel inputModel)
        {
            var harvest = await _harvestServices.CreateAsync(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = harvest.Id }, harvest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateHarvestInputModel inputModel)
        {
            var harvest = await _harvestServices.UpdateAsync(id, inputModel);
            return Ok(harvest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var harvest = await _harvestServices.DeleteAsync(id);
            return NoContent();
        }
    }
} 