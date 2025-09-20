



using System.Text.RegularExpressions;
using System.Text.Json.Nodes;

namespace Application.Module.IA
{
    public interface IMetrics
    {
        JsonArray GenerateReports(JsonArray data);
        JsonArray generateReports1(JsonArray data);
        JsonArray generateCharts();
    }

    public class Metrics : IMetrics
    {
        public JsonArray generateCharts()
        {
            throw new NotImplementedException();
        }

        public JsonArray generateReports1(JsonArray data)
        {
            // quantos % ele acerta (resposta correta em uma das 3 )
            // quantos % ele erra (resposta errada nao esta em nenhuma das 3)
            // quantos % ele acerta na primeira (resposta correta na posicao 1)
            // quantos % ele acerta na segunda (resposta correta na posicao 2
            // quantos % ele acerta na terceira (resposta correta na posicao 3)
            throw new NotImplementedException();
        }

        public JsonArray GenerateReports(JsonArray data)
        {
            int total = data.Count;
            int acertos = 0, erros = 0;
            int pos1 = 0, pos2 = 0, pos3 = 0;

            foreach (var item in data)
            {
                var idRaw = item?["id"]?.ToString() ?? "";
                var responses = item?["response"]?.AsArray();
                if (responses == null || responses.Count == 0) continue;

                // Normaliza o ID: remove parênteses, espaços extras e coloca em maiúsculo
                var expected = Regex.Replace(idRaw, @"\s*\(.*\)", "").Trim().ToUpper();

                bool acertou = false;

                for (int i = 0; i < responses.Count; i++)
                {
                    var diag = responses[i]?["diagnostic"]?.ToString()?.Trim().ToUpper() ?? "";

                    if (diag.Contains(expected))
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

            // Calcula % relativos
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
                    ["acertos"] = $"{pAcerto:F2}%",
                    ["erros"] = $"{pErro:F2}%",
                    ["acertos_pos1"] = $"{pPos1:F2}%",
                    ["acertos_pos2"] = $"{pPos2:F2}%",
                    ["acertos_pos3"] = $"{pPos3:F2}%"
                }
            };

            return report;
        }

    }
}