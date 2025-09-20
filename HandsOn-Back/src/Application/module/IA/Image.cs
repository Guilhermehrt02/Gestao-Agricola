

namespace Application.Module.IA
{
    public interface IImage
    {
        string EncodeBase64(string data);
    }

    public class Image : IImage
    {
        public string Data { get; set; }
        public string Type { get; set; }

        public Image(string data, string type)
        {
            Data = data;
            Type = type;
        }

        public string EncodeBase64(string data)
        {
            var base64 = Convert.ToBase64String(File.ReadAllBytes(Data));
            return $"data:{Type};base64,{base64}";
        }


        public static string GetFileName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }
    }

}