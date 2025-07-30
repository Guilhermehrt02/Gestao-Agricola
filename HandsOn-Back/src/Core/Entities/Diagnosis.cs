using Core.Enums;

namespace Core.Entities
{
    public class Diagnosis
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Farm Farm { get; set; } = new Farm();
        public Harvest Harvest { get; set; } = new Harvest();
        public Plot Plot { get; set; } = new Plot();
        public UploadType UploadType { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DiagnosisStatus Status { get; set; } = DiagnosisStatus.Pending;
        public string Result { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

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
            double? longitude = null
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
            string? result = null,
            DiagnosisStatus? status = null
        )
        {
            UploadType = UploadTypeExtension.ToUploadType(uploadType ?? UploadType.ToFriendlyString());
            PhotoUrl = photoUrl ?? PhotoUrl;
            Date = date ?? Date;
            Farm = farm ?? Farm;
            UserId = userId ?? UserId;
            Harvest = harvest ?? Harvest;
            Plot = plot ?? Plot;
            Status = status ?? Status;
            Result = result ?? Result;
            Latitude = latitude ?? Latitude;
            Longitude = longitude ?? Longitude;

            UpdatedAt = DateTime.Now;
        }
    }
}