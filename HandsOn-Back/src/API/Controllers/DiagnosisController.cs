using Microsoft.AspNetCore.Authorization;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.InputModels.DiagnosisModels;

namespace API.Controllers
{
    [ApiController]
    [Route("api/diagnosis")]
    [Authorize]
    public class DiagnosisController(IDiagnosisServices diagnosisServices) : ControllerBase
    {
        private readonly IDiagnosisServices _diagnosisServices = diagnosisServices;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var diagnosis = await _diagnosisServices.GetByIdAsync(id);
            return Ok(diagnosis);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllByUserId(Guid userId)
        {
            var diagnoses = await _diagnosisServices.GetAllByUserIdAsync(userId);
            return Ok(diagnoses);
        }

        [HttpGet("farm/{farmId}")]
        public async Task<IActionResult> GetAllByFarmId(Guid farmId)
        {
            var diagnoses = await _diagnosisServices.GetAllByFarmIdAsync(farmId);
            return Ok(diagnoses);
        }

        [HttpGet("plot/{plotId}")]
        public async Task<IActionResult> GetAllByPlotId(Guid plotId)
        {
            var diagnoses = await _diagnosisServices.GetAllByPlotIdAsync(plotId);
            return Ok(diagnoses);
        }

        [HttpGet("harvest/{harvestId}")]
        public async Task<IActionResult> GetAllByHarvestId(Guid harvestId)
        {
            var diagnoses = await _diagnosisServices.GetAllByHarvestIdAsync(harvestId);
            return Ok(diagnoses);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiagnosisInputModel inputModel)
        {
            var diagnosis = await _diagnosisServices.CreateAsync(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = diagnosis.Id }, diagnosis);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDiagnosisInputModel inputModel)
        {
            var diagnosis = await _diagnosisServices.UpdateAsync(id, inputModel);
            return Ok(diagnosis);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var diagnosis = await _diagnosisServices.DeleteAsync(id);
            return NoContent();
        }
    }
}