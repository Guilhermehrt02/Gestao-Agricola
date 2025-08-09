namespace Application.InputModels.DiagnosisModels
{
    public class CreateLocationShape
    {
        public string Type { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public CreateCoordinates[] Coordinates { get; set; } = Array.Empty<CreateCoordinates>();
    }
}