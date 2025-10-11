using Microsoft.AspNetCore.Http;

namespace Application.InputModels.DiseaseModels
{
    public class UpdateDiseaseInputModel
    {
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Class { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; } = null!;
        public string? Symptoms { get; set; } = string.Empty;
        public string? Prevention { get; set; } = string.Empty;
        public string? Recommendation { get; set; } = string.Empty;
    }
}
    