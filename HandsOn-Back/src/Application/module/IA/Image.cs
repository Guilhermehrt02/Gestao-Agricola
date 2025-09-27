

using Microsoft.AspNetCore.Http;

namespace Application.Module.IA
{
    public interface IImage
    {
        string GetFileName();
    }

    public class Image(IFormFile data) : IImage
    {
        public IFormFile ImageBuffer { get; set; } = data;
        public string Type { get; set; } = data.ContentType.Split('/').Last();

        public string GetFileName()
        {
            return ImageBuffer.FileName;
        }

        public string EncodeBase64()
        {
            using var memoryStream = new MemoryStream();
            ImageBuffer.CopyTo(memoryStream);
            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }

}