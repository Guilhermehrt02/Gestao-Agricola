using System.Text.Json.Serialization;

namespace Application.InputModels.DiagnosisModels
{
    public class UpdateDiagnosisResultInputModel
    {
        [JsonPropertyName("images_book")]
        public string ImagesBook { get; set; } = string.Empty;

        [JsonPropertyName("similarity")]
        public double Similarity { get; set; }
    }
}