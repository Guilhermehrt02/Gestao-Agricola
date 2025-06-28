using Microsoft.AspNetCore.Authorization;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.InputModels.PlotModels;

namespace API.Controllers
{
    [ApiController]
    [Route("api/plot")]
    [Authorize]
    public class PlotController(IPlotServices plotServices) : ControllerBase
    {
        private readonly IPlotServices _plotServices = plotServices;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var plot = await _plotServices.GetByIdAsync(id);
            return Ok(plot);
        }

        [HttpGet("farm/{farmId}")]
        public async Task<IActionResult> GetAllByFarmIdAsync(Guid farmId)
        {
            var plots = await _plotServices.GetAllByFarmIdAsync(farmId);
            return Ok(plots);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePlotInputModel inputModel)
        {
            var plot = await _plotServices.CreateAsync(inputModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = plot.Id }, plot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdatePlotInputModel inputModel)
        {
            var plot = await _plotServices.UpdateAsync(id, inputModel);
            return plot is not null ? Ok(plot) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var plot = await _plotServices.DeleteAsync(id);
            return plot is not null ? NoContent() : NotFound();
        }
    }
}