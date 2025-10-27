using Core.Enums;

namespace Core.Entities
{
    public class Diagnosis
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Farm Farm { get; set; } = new Farm();
        public Guid FarmId { get; set; }
        public Harvest Harvest { get; set; } = new Harvest();
        public Plot Plot { get; set; } = new Plot();
        public UploadType UploadType { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DiagnosisStatus Status { get; set; } = DiagnosisStatus.Pending;
        public DiagnosisResult? Result { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<LocationShape> LocationShapes { get; set; } = new(); // ✅

        public Diagnosis() { }

        public Diagnosis(
            Guid userId,
            Farm farm,
            Harvest harvest,
            Plot plot,
            string uploadType,
            string photoUrl,
            DateTime? date,
            double? latitude = null,
            double? longitude = null,
            List<LocationShape>? locationShapes = null
        )
        {
            UserId = userId;
            Farm = farm;
            Harvest = harvest;
            Plot = plot;
            UploadType = UploadTypeExtension.ToUploadType(uploadType);
            PhotoUrl = photoUrl;
            Date = date ?? DateTime.Now;
            Status = DiagnosisStatus.Pending;
            Latitude = latitude;
            Longitude = longitude;
            LocationShapes = locationShapes;
            Result = null;
        }

        public void Update(
            string? uploadType,
            string? photoUrl,
            DateTime? date,
            Farm? farm = null,
            Guid? userId = null,
            Harvest? harvest = null,
            Plot? plot = null,
            double? latitude = null,
            double? longitude = null,
            List<LocationShape>? locationShapes = null,
            string? status = null
        )
        {
            UploadType = UploadTypeExtension.ToUploadType(uploadType ?? UploadType.ToFriendlyString());
            PhotoUrl = photoUrl ?? PhotoUrl;
            Date = date ?? Date;
            Farm = farm ?? Farm;
            FarmId = farm?.Id ?? FarmId;
            UserId = userId ?? UserId;
            Harvest = harvest ?? Harvest;
            Plot = plot ?? Plot;
            Latitude = latitude ?? Latitude;
            Longitude = longitude ?? Longitude;
            UpdatedAt = DateTime.Now;
            LocationShapes = locationShapes ?? LocationShapes;
            Status = DiagnosisStatusExtension.ToDiagnosisStatus(status ?? Status.ToFriendlyString());
        }
        public void UpdateResult(DiagnosisResult result)
        {
            Result = result;
            Status = DiagnosisStatus.Processed;
            UpdatedAt = DateTime.Now;
        }
    }
}