using Application.InputModels.DiagnosisModels;

namespace Application.Services
{
    public interface IAIServiceClient
    {
        Task<List<UpdateDiagnosisResultInputModel>> StartProcessingAsync(Guid diagnosisId, string imagePath);
    }
}