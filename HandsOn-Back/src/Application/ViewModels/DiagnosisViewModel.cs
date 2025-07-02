using Core.Entities;
using Core.Enums;

namespace Application.ViewModels
{
    public class DiagnosisViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FarmId { get; set; }
        public Guid HarvestId { get; set; }
        public Guid PlotId { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = String.Empty;
        public string? Result { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public static DiagnosisViewModel FromEntity(Diagnosis diagnosis)
        {
            return new DiagnosisViewModel
            {
                Id = diagnosis.Id,
                UserId = diagnosis.UserId,
                FarmId = diagnosis.FarmId,
                HarvestId = diagnosis.HarvestId,
                PlotId = diagnosis.PlotId,
                PhotoUrl = diagnosis.PhotoUrl,
                Date = diagnosis.Date,
                Status = diagnosis.Status.ToFriendlyString(),
                Result = diagnosis.Result,
                Latitude = diagnosis.Latitude,
                Longitude = diagnosis.Longitude,
                CreatedAt = diagnosis.CreatedAt,
                UpdatedAt = diagnosis.UpdatedAt
            };
        }
    }
}