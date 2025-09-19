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
        public async Task<IActionResult> GetAll()
        {
            var farms = await _farmServices.GetAllByUserIdAsync(User);
            return Ok(farms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var farm = await _farmServices.GetByIdAsync(id);
            return Ok(farm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFarmInputModel inputModel)
        {
            var farm = await _farmServices.CreateAsync(User, inputModel);
            return CreatedAtAction(nameof(GetById), new { id = farm.Id }, farm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateFarmInputModel inputModel)
        {
            var farm = await _farmServices.UpdateAsync(id, inputModel);
            return Ok(farm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var farm = await _farmServices.DeleteAsync(id);
            return NoContent();
        }
    }
}