using System.Net.Http.Json;

namespace Application.Services
{
    public class AIServiceClient(HttpClient httpClient) : IAIServiceClient
    {
        public readonly HttpClient _httpClient = httpClient;

        public async Task StartProcessingAsync(Guid diagnosisId, string imagePath)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/process", new
            {
                DiagnosisId = diagnosisId,
                ImagePath = imagePath
            });

            response.EnsureSuccessStatusCode();
        }
    }
}
