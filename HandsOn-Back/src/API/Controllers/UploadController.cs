using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class UploadController(IUploadServices uploadServices) : ControllerBase
    {
        private readonly IUploadServices _uploadServices = uploadServices;

        /// <summary>
        /// This method uploads a file to the server
        /// </summary>
        /// <returns>File URL</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("file")]
        public async Task<IActionResult> UploadFile([FromForm] string? description, [FromForm] DateTime? clientDate, IFormFile file)
        {

            var relativePath = await _uploadServices.UploadFileAsync(file);

            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var fileUrl = $"{baseUrl}/{relativePath}";

            return Ok(new
            {
                FileUrl = fileUrl,
            });
        }

        [HttpPost("Classifier")]
        public async Task<IActionResult> Classifier([FromForm] IFormFile file)
        {
            var response = await _uploadServices.RunClassifier(file);

            return Ok(new
            {
                Message = "Executed successfully",
                Response = response
            });
        }

    }


}