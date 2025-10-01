using Microsoft.AspNetCore.Authorization;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.InputModels.DiseaseModels;

namespace API.Controllers
{
    [ApiController]
    [Route("api/disease")]
    [Authorize]
    public class DiseaseController(IDiseaseService diseaseService) : ControllerBase
    {
        private readonly IDiseaseService _diseaseService = diseaseService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var disease = await _diseaseService.GetByIdAsync(id);
            return Ok(disease);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var diseases = await _diseaseService.GetAllAsync();
            return Ok(diseases);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiseaseInputModel inputModel)
        {
            var disease = await _diseaseService.CreateAsync(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = disease.Id }, disease);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDiseaseInputModel inputModel)
        {
            var disease = await _diseaseService.UpdateAsync(id, inputModel);
            return Ok(disease);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _ = await _diseaseService.DeleteAsync(id);
            return NoContent();
        }
    }
}