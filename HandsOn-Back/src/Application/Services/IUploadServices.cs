using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IUploadServices
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task DeleteFileAsync(string filePath);
        Task RunClassifier();
    }
}