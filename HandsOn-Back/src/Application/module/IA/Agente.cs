
using System.Text.Json.Nodes;

namespace Application.Module.IA
{
    public interface IAgente
    {
        Task Init();
        string loadPrompt(string path);
        List<Image> loadImages(string path);
        void generateJSON(string path, string fileName, JsonArray json);

    }

    public class Agente : IAgente
    {
        public List<Image> Images { get; set; } = new();
        private readonly IGPT _GPT = new GPT();
        private readonly IMetrics _Metrics = new Metrics();

        public async Task Init()
        {
            var path_prompt = "C:/Users/carlos/Documents/GITHUB/Gestao-Agricola/HandsOn-Back/src/Application/module/IA/Prompt.txt";
            var prompt = loadPrompt(path_prompt);

            var path_images = "C:/Users/carlos/Documents/GITHUB/Gestao-Agricola/HandsOn-Back/src/Application/module/IA/images/Ferrugem/ferrugem (2).jpeg";
            var imagesReq = loadImages(path_images);
            var fileName = Image.GetFileName(path_images);

            var payload = _GPT.GeneratePayload(prompt, imagesReq);
            var response = await _GPT.Request(payload);

            // Console.WriteLine(response);
            var path_diagnostico = "C:/Users/carlos/Documents/GITHUB/Gestao-Agricola/HandsOn-Back/src/Application/module/IA/diagnostics.json";
            var json = JsonNode.Parse(response)?.AsArray();
            Console.WriteLine(json);

            if (json == null) return;

            generateJSON(path_diagnostico, fileName, json);

            var existingDiag = File.ReadAllText(path_diagnostico);
            var existingArray = JsonNode.Parse(existingDiag)?.AsArray();
            if (existingArray == null) return;
            var report = _Metrics.GenerateReports(existingArray);
            Console.WriteLine(report);

        }

        public string loadPrompt(string path)
        {
            using StreamReader sr = new(path);
            return sr.ReadToEnd();
        }

        public List<Image> loadImages(string path)
        {
            var image = new Image(path, "jpeg");
            Images.Add(image);
            return Images;
        }

        public void generateJSON(string path, string fileName, JsonArray jsonGPT)
        {
            JsonArray finalArray;

            if (!File.Exists(path)) return;
            try
            {
                var existingJson = File.ReadAllText(path);
                var existingArray = JsonNode.Parse(existingJson)?.AsArray();
                if (existingArray == null) return;

                finalArray = existingArray;

                var obj = new JsonObject
                {
                    ["id"] = fileName,
                    ["response"] = jsonGPT
                };

                finalArray.Add(obj);
            }
            catch
            {
                // Se der erro ao ler/parsear, recria o arquivo
                finalArray = [.. jsonGPT];
            }

            File.WriteAllText(path, finalArray.ToJsonString(new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }

    }

}