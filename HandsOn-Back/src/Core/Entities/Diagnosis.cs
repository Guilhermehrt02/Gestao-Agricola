using Core.Enums;

namespace Core.Entities
{
    public class Diagnosis
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FarmId { get; set; } //ou melhor referenciar a uma Farm?
        public Guid HarvestId { get; set; } //ou melhor referenciar a uma Harvest?
        public Guid PlotId { get; set; } //ou melhor referenciar a uma Plot?
        public UploadType UploadType { get; set; } //usuário pode escolher o tipo de upload?
        public string? PhotoUrl { get; set; }
        public DateTime Date { get; set; }
        public DiagnosisStatus Status { get; set; } = DiagnosisStatus.Pending;
        public string? Result { get; set; }
        public double? Latitude { get; set; }   // Coordenada GPS
        public double? Longitude { get; set; }  // Coordenada GPS
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Diagnosis() { }

        public Diagnosis(
            Guid userId,
            Guid farmId,
            Guid harvestId,
            Guid plotId,
            string uploadType,
            string photoUrl,
            DateTime? date,
            double? latitude = null,
            double? longitude = null
        )
        {
            UserId = userId;
            FarmId = farmId;
            HarvestId = harvestId;
            PlotId = plotId;
            UploadType = UploadTypeExtension.ToUploadType(uploadType);
            PhotoUrl = photoUrl;
            Date = date ?? DateTime.Now;
            Status = DiagnosisStatus.Pending; 
            Latitude = latitude;
            Longitude = longitude;
        }

        public void Update(
            string? uploadType,
            string? photoUrl,
            DateTime? date,
            DiagnosisStatus? status,
            string? result,
            double? latitude = null,
            double? longitude = null
        )
        {
            UploadType = UploadTypeExtension.ToUploadType(uploadType ?? UploadType.ToFriendlyString());
            PhotoUrl = photoUrl ?? PhotoUrl;
            Date = date ?? Date;
            Status = status ?? Status;
            Result = result ?? Result;
            Latitude = latitude ?? Latitude;
            Longitude = longitude ?? Longitude;

            UpdatedAt = DateTime.Now;
        }
    }
}