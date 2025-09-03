namespace Application.Services
{
    public interface IAIServiceClient
    {
        Task StartProcessingAsync(Guid diagnosisId, string imagePath);
    }
}