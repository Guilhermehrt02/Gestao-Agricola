using Microsoft.AspNetCore.Authorization;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.InputModels.UserFarmModels;

namespace API.Controllers
{
    [ApiController]
    [Route("api/user-farm")]
    [Authorize]
    public class UserFarmController(IUserFarmServices userFarmServices) : ControllerBase
    {
        private readonly IUserFarmServices _userFarmServices = userFarmServices;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _userFarmServices.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserIdAsync(Guid userId)
        {
            var results = await _userFarmServices.GetByUserIdAsync(userId);
            return Ok(results);
        }

        [HttpGet("farm/{farmId}")]
        public async Task<IActionResult> GetByFarmIdAsync(Guid farmId)
        {
            var results = await _userFarmServices.GetByFarmIdAsync(farmId);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserFarmInputModel inputModel)
        {
            var result = await _userFarmServices.CreateAsync(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateUserFarmInputModel inputModel)
        {
            var result = await _userFarmServices.UpdateAsync(id, inputModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _userFarmServices.DeleteAsync(id);
            return Ok(result);
        }
    }
}