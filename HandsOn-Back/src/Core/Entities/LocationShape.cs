using Core.Enums;

namespace Core.Entities
{
    public class LocationShape
    {
        public Guid Id { get; set; }
        public Guid DiagnosisId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public Coordinate[] Coordinates { get; set; } = Array.Empty<Coordinate>();
    }

}