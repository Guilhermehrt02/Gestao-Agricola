using Core.Entities;
using Core.Enums;
using Application.ViewModels.FarmModels;
using Application.ViewModels.HarvestModels;
using Application.ViewModels.PlotModels;

namespace Application.ViewModels
{
    public class DiagnosisViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public FarmDataModel Farm { get; set; }
        public HarvestDataModel Harvest { get; set; }
        public PlotDataModel Plot { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = String.Empty;
        public string? UploadType { get; set; }
        public string? Result { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<LocationShapeViewModel>? LocationShapes { get; set; }

        public static DiagnosisViewModel FromEntity(Diagnosis diagnosis)
        {
            return new DiagnosisViewModel
            {
                Id = diagnosis.Id,
                UserId = diagnosis.UserId,
                Farm = FarmDataModel.FromEntity(diagnosis.Farm),
                Harvest = HarvestDataModel.FromEntity(diagnosis.Harvest),
                Plot = PlotDataModel.FromEntity(diagnosis.Plot),
                PhotoUrl = diagnosis.PhotoUrl,
                Date = diagnosis.Date,
                Status = diagnosis.Status.ToFriendlyString(),
                UploadType = diagnosis.UploadType.ToFriendlyString(),
                Result = diagnosis.Result,
                Latitude = diagnosis.Latitude,
                Longitude = diagnosis.Longitude,
                CreatedAt = diagnosis.CreatedAt,
                UpdatedAt = diagnosis.UpdatedAt,
                LocationShapes = diagnosis.LocationShapes?
                    .Select(LocationShapeViewModel.FromEntity)
                    .ToList()
            };
        }
    }
}