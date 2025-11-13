using Core.Enums;

namespace Core.Entities
{
    public class LocationShape
    {
        public Guid Id { get; set; }
        public Guid? DiagnosisId { get; set; }
        public Diagnosis? Diagnosis { get; set; }

        public Guid? FarmId { get; set; }
        public Farm? Farm { get; set; }
        public Guid? PlotId { get; set; }
        public Plot? Plot { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
    }

}