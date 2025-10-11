using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.DiseaseModels
{
    public class CreateDiseaseInputModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Class is required.")]
        public string Class { get; set; } = string.Empty;

        [Required(ErrorMessage = "ImageFile is required.")]
        public IFormFile ImageFile { get; set; } = null!;

        [Required(ErrorMessage = "Symptoms are required.")]
        public string Symptoms { get; set; } = string.Empty;

        [Required(ErrorMessage = "Prevention is required.")]
        public string Prevention { get; set; } = string.Empty;

        [Required(ErrorMessage = "Recommendation is required.")]
        public string Recommendation { get; set; } = string.Empty;
    }
}