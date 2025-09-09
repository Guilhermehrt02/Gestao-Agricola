using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using Application.InputModels.DiagnosisModels;

namespace Application.Services
{
    public class AIServiceClient(HttpClient httpClient) : IAIServiceClient
    {
        public readonly HttpClient _httpClient = httpClient;

        public async Task<List<UpdateDiagnosisResultInputModel>> StartProcessingAsync(Guid diagnosisId, string imageUrl)
        {
            using var imageResponse = await _httpClient.GetAsync(imageUrl);
            imageResponse.EnsureSuccessStatusCode();
            var imageBytes = await imageResponse.Content.ReadAsByteArrayAsync();

            using var form = new MultipartFormDataContent
            {
                { new StringContent(diagnosisId.ToString()), "diagnosisId" }
            };

            var fileContent = new ByteArrayContent(imageBytes);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            form.Add(fileContent, "imagem", "upload.jpg");

            var response = await _httpClient.PostAsync("/compare", form);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var results = await JsonSerializer.DeserializeAsync<List<UpdateDiagnosisResultInputModel>>(stream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return results ?? [];
        }
    }
}
