
using System.Runtime.InteropServices;
using System.Text.Json.Nodes;

namespace Application.Module.IA
{
    public interface IClassifier
    {
        Task<JsonArray?> SendImageIA(Image image);
        string LoadPrompt();
        void GenerateJSON(string? fileName, JsonArray jsonGPT);
        void GenerateMetrics();
    }

    public class Classifier : IClassifier
    {
        public List<IImage> Images { get; set; } = [];
        private readonly GPT _GPT = new();
        private readonly IAIProvider _IAProvider;
        private readonly Metrics _Metrics = new();
        private readonly string Prompt = "";
        private readonly string Path_diagnostico = "C:/Users/carlos/Documents/GITHUB/Gestao-Agricola/HandsOn-Back/src/Application/module/IA/diagnostics.json";
        private readonly string Path_prompt = "C:/Users/carlos/Documents/GITHUB/Gestao-Agricola/HandsOn-Back/src/Application/module/IA/Prompt.txt";

        public Classifier()
        {
            Prompt = LoadPrompt();
            _IAProvider = new IAProvider(_GPT);

        }

        public async Task<JsonArray?> SendImageIA(Image image)
        {
            // var payload = _IAProvider.GeneratePayload(Prompt, image);
            // var response = await _IAProvider.Request(payload);

            // var responseJsonGPT = JsonNode.Parse(response)?.AsArray();
            // if (responseJsonGPT == null) return null;


            // GenerateJSON(image.GetFileName(), responseJsonGPT);
            // return responseJsonGPT;

            GenerateMetrics();
            return null;
        }

        public void GenerateMetrics()
        {
            var existingDiagnostic = File.ReadAllText(Path_diagnostico);
            var existingArray = JsonNode.Parse(existingDiagnostic)?.AsArray();
            if (existingArray == null) return;

            var report = _Metrics.GenerateReports(existingArray);
            Console.WriteLine(report.ToJsonString(new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }


        public string LoadPrompt()
        {
            using StreamReader sr = new(Path_prompt);
            return sr.ReadToEnd();
        }

        public void GenerateJSON(string? fileName, JsonArray jsonGPT)
        {
            JsonArray finalArray;

            if (!File.Exists(Path_diagnostico)) return;
            try
            {
                var existingJson = File.ReadAllText(Path_diagnostico);
                var existingArray = JsonNode.Parse(existingJson)?.AsArray();
                if (existingArray == null) return;

                finalArray = existingArray;

                var obj = new JsonObject
                {
                    ["id"] = fileName ?? "",
                    ["response"] = jsonGPT
                };

                finalArray.Add(obj);
            }
            catch
            {
                // Se der erro ao ler/parsear, recria o arquivo
                finalArray = [.. jsonGPT];
            }

            File.WriteAllText(Path_diagnostico, finalArray.ToJsonString(new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }

    }

}