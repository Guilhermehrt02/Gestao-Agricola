namespace Core.Entities
{
    public class DiagnosisResult
    {
        public Guid Id { get; set; }         // PK
        public Guid DiagnosisId { get; set; } // FK
        public List<ImageSimilarity> Similarities { get; set; } = new List<ImageSimilarity>();
        public Diagnosis Diagnosis { get; set; } = null!;
    }

    public class ImageSimilarity
    {
        public Guid Id { get; set; }
        public Guid DiagnosisResultId { get; set; }
        public DiagnosisResult DiagnosisResult { get; set; } = null!;
        public string ImageBook { get; set; } = string.Empty;
        public double Similarity { get; set; }
    }
}