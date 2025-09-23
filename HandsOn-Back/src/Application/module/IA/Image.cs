

namespace Application.Module.IA
{
    public interface IImage
    {
        string EncodeBase64();
        string GetFileName();
    }

    public class Image : IImage
    {
        public string ImagePath { get; set; }
        public string Type { get; set; }

        public Image(string data, string type)
        {
            ImagePath = data;
            Type = type;
        }

        public string EncodeBase64()
        {
            var base64 = Convert.ToBase64String(File.ReadAllBytes(ImagePath));
            return $"data:{Type};base64,{base64}";
        }


        public string GetFileName()
        {
            return Path.GetFileNameWithoutExtension(ImagePath);
        }
    }

}