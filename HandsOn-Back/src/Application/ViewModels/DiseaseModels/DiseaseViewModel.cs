using Core.Entities;
using Core.Enums;
namespace Application.ViewModels.DiseaseModels
{
    public class DiseaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string ReferenceImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string Symptoms { get; set; } = string.Empty;
        public string Prevention { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;

        public static DiseaseViewModel FromEntity(Disease disease)
        {
            return new DiseaseViewModel
            {
                Id = disease.Id,
                Name = disease.Name,
                Description = disease.Description,
                Class = disease.Class.ToFriendlyString(),
                ReferenceImageUrl = disease.ReferenceImageUrl,
                CreatedAt = disease.CreatedAt,
                UpdatedAt = disease.UpdatedAt,
                Symptoms = disease.Symptoms,
                Prevention = disease.Prevention,
                Recommendation = disease.Recommendation
            };
        }
    }
}