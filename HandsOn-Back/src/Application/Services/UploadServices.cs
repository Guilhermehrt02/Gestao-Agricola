using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class UploadServices(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor) : IUploadServices
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file.Length == 0 || file == null)
            {
                throw new ArgumentException("File is empty");
            }
            if (file.Length > 5 * 1024 * 1024)
            {
                throw new ArgumentException("File size exceeds the limit of 5 MB");
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath ?? "wwwroot", "uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"uploads/{fileName}";
        }


        public Task DeleteFileAsync(string relativePath)
        {
            var uri = new Uri(relativePath);
            var cleanRelativePath = uri.AbsolutePath.TrimStart('/');

            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath ?? "wwwroot", cleanRelativePath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            return Task.CompletedTask;
        }
    }
}