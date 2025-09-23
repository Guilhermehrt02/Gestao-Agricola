

using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace Application.Module.IA
{
    public interface IMetrics
    {
        JsonArray GenerateReports(JsonArray data);
    }

    public partial class Metrics : IMetrics
    {
        [GeneratedRegex(@"\s*\(.*\)|\d")]
        private static partial Regex MyRegex();
        public JsonArray GenerateReports(JsonArray DiagnosticsJson)
        {
            int total = DiagnosticsJson.Count;
            int acertos = 0, erros = 0;
            int pos1 = 0, pos2 = 0, pos3 = 0;

            foreach (var item in DiagnosticsJson)
            {
                var idRaw = item?["id"]?.ToString() ?? "";
                var responses = item?["response"]?.AsArray();
                if (responses == null || responses.Count == 0) continue;

                // Normaliza o ID: remove parênteses, numeros, espaços extras e coloca em maiúsculo
                var expected = MyRegex().Replace(idRaw, "").Trim().ToUpper();

                bool acertou = false;
                int number_responses = 3;

                for (int i = 0; i < number_responses; i++)
                {
                    var diagGPT = responses[i]?["diagnostic"]?.ToString()?.Trim().ToUpper() ?? "";

                    if (diagGPT.Contains(expected))
                    {
                        acertou = true;

                        if (i == 0) pos1++;
                        else if (i == 1) pos2++;
                        else if (i == 2) pos3++;

                        break; // achou, não precisa verificar mais
                    }
                }

                if (acertou) acertos++;
                else erros++;
            }

            double pAcerto = total > 0 ? acertos * 100.0 / total : 0;
            double pErro = total > 0 ? erros * 100.0 / total : 0;
            double pPos1 = total > 0 ? pos1 * 100.0 / total : 0;
            double pPos2 = total > 0 ? pos2 * 100.0 / total : 0;
            double pPos3 = total > 0 ? pos3 * 100.0 / total : 0;

            var report = new JsonArray
            {
                new JsonObject
                {
                    ["total"] = total,
                    ["acertos"] = $"{acertos}",
                    ["erros"] = $"{erros}",
                    ["acertos_pos1"] = $"{pos1}",
                    ["acertos_pos2"] = $"{pos2}",
                    ["acertos_pos3"] = $"{pos3}",

                    ["% acertos"] = $"{pAcerto:F2}%",
                    ["% erros"] = $"{pErro:F2}%",
                    ["% acertos_pos1"] = $"{pPos1:F2}%",
                    ["% acertos_pos2"] = $"{pPos2:F2}%",
                    ["% acertos_pos3"] = $"{pPos3:F2}%"
                }
            };

            return report;
        }
    }
}