using System.Text.Json.Nodes;
using Application.Module.IA;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class UploadServices(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IClassifier classifier) : IUploadServices
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

        public async Task<List<Image>> GetAllFilesFromFolderAndProcess(string path)
        {
            var uploadsFolder = path;
            Console.WriteLine($"Procurando imagens na pasta: {uploadsFolder}");

            if (!Directory.Exists(uploadsFolder))
                return new List<Image>();

            var processedImages = new List<Image>();
            var imageExtensions = new[] { ".jpg", ".jpeg", ".png" };

            // Busca recursivamente todos os arquivos de imagem
            var imageFiles = Directory.GetFiles(uploadsFolder, "*.*", SearchOption.AllDirectories)
                                     .Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLowerInvariant()))
                                     .ToList();

            Console.WriteLine($"Encontradas {imageFiles.Count} imagens para processar.");

            for (int i = 0; i < imageFiles.Count; i++)
            {
                try
                {
                    var filePath = imageFiles[i];
                    var relativePath = Path.GetRelativePath(uploadsFolder, filePath)
                                           .Replace("\\", "/");

                    // Cria o objeto Image (assumindo que você tem esse construtor ou método)
                    var image = CreateImageFromFile(filePath, relativePath);

                    // Chama a API de classificação
                    await classifier.SendImageIA(image);

                    processedImages.Add(image);

                    Console.WriteLine($"Processada imagem {i + 1}/{imageFiles.Count}: {relativePath}");

                    // A cada 10 imagens, espera 5 segundos
                    if ((i + 1) % 10 == 0 && i + 1 < imageFiles.Count)
                    {
                        Console.WriteLine($"Processadas {i + 1} imagens. Aguardando 5 segundos...");
                        await Task.Delay(5000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao processar imagem {imageFiles[i]}: {ex.Message}");
                    // Continue processando as outras imagens mesmo se uma falhar
                }
            }

            Console.WriteLine($"Processamento concluído. Total: {processedImages.Count} imagens processadas.");
            return processedImages;
        }

        // Método auxiliar para criar o objeto Image a partir do arquivo
        private Image CreateImageFromFile(string filePath, string relativePath)
        {
            var imageBytes = File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(filePath);
            var extension = Path.GetExtension(filePath).TrimStart('.').ToLowerInvariant();
            var contentType = GetContentType(extension);

            // Cria um IFormFile a partir dos bytes do arquivo
            var formFile = new FormFileFromBytes(imageBytes, fileName, contentType);

            return new Image(formFile);
        }

        // Método auxiliar para obter o Content-Type baseado na extensão
        private string GetContentType(string extension)
        {
            return extension.ToLowerInvariant() switch
            {
                "jpg" or "jpeg" => "image/jpeg",
                "png" => "image/png",
                "gif" => "image/gif",
                "bmp" => "image/bmp",
                "tiff" or "tif" => "image/tiff",
                "webp" => "image/webp",
                _ => "image/jpeg"
            };
        }

        // Classe auxiliar para criar IFormFile a partir de bytes
        public class FormFileFromBytes : IFormFile
        {
            private readonly byte[] _fileBytes;
            private readonly string _fileName;
            private readonly string _contentType;

            public FormFileFromBytes(byte[] fileBytes, string fileName, string contentType)
            {
                _fileBytes = fileBytes;
                _fileName = fileName;
                _contentType = contentType;
            }

            public string ContentType => _contentType;
            public string ContentDisposition => $"form-data; name=\"file\"; filename=\"{_fileName}\"";
            public IHeaderDictionary Headers => new HeaderDictionary();
            public long Length => _fileBytes.Length;
            public string Name => "file";
            public string FileName => _fileName;

            public Stream OpenReadStream()
            {
                return new MemoryStream(_fileBytes);
            }

            public void CopyTo(Stream target)
            {
                using var stream = OpenReadStream();
                stream.CopyTo(target);
            }

            public async Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
            {
                using var stream = OpenReadStream();
                await stream.CopyToAsync(target, cancellationToken);
            }
        }

        public async Task<JsonArray?> RunClassifier(IFormFile file)
        {
            var image = new Image(file);
            return await classifier.SendImageIA(image);

            // var processedImages = await GetAllFilesFromFolderAndProcess("C:/Users/carlos/Documents/GITHUB/Gestao-Agricola/HandsOn-Back/src/Application/module/IA/dataset");
            // Console.WriteLine($"Total de imagens processadas: {processedImages.Count}");
            // return null;
        }
    }
}