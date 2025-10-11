using Core.Enums;

namespace Core.Entities
{
    public class Disease
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; } = string.Empty;
        public string Prevention { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
        public UploadType Class { get; set; }
        public string ReferenceImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Disease() { }

        public Disease(string name, string description,  string uploadType, string referenceImageUrl, string symptoms, string prevention, string recommendation)
        {
            Name = name;
            Description = description;
            Class = UploadTypeExtension.ToUploadType(uploadType);
            ReferenceImageUrl = referenceImageUrl;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Symptoms = symptoms;
            Prevention = prevention;
            Recommendation = recommendation;
        }
        
        public void Update(
            string? name,
            string? description,
            string? uploadType,
            string? referenceImageUrl,
            string? symptoms,
            string? prevention,
            string? recommendation
        )
        {
            Name = name ?? Name;
            Description = description ?? Description;
            Class = uploadType != null ? UploadTypeExtension.ToUploadType(uploadType) : Class;
            ReferenceImageUrl = referenceImageUrl ?? ReferenceImageUrl;
            Symptoms = symptoms ?? Symptoms;
            Prevention = prevention ?? Prevention;
            Recommendation = recommendation ?? Recommendation;
            UpdatedAt = DateTime.Now;
        }

    }
}