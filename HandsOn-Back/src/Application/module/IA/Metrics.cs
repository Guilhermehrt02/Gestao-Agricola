

using System.Text.Json;
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
        [GeneratedRegex(@"\s*\([^)]*\)|\d+")]
        private static partial Regex RemoveParenthesesAndNumbers();

        [GeneratedRegex(@"[_\s]+")]
        private static partial Regex NormalizeSpaces();

        private static string NormalizeClassname(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            // Remove extensões de arquivo
            input = Path.GetFileNameWithoutExtension(input);

            // Remove parênteses com conteúdo e números
            input = RemoveParenthesesAndNumbers().Replace(input, "");

            // Substitui underscores e múltiplos espaços por espaço único
            input = NormalizeSpaces().Replace(input, " ");

            // Remove espaços no início e fim, converte para maiúsculo
            return input.Trim().ToUpper();
        }

        private static Dictionary<string, string[]> CreateClassMappings()
        {
            return new Dictionary<string, string[]>
            {
                ["BICHO MINEIRO"] = ["BICHO-MINEIRO", "BICHO_MINEIRO", "MINEIRO"],
                ["BICHO-MINEIRO"] = ["BICHO MINEIRO", "BICHO_MINEIRO", "MINEIRO"],
                ["ACARO BRANCO"] = ["ACARO-BRANCO", "ACARO_BRANCO"],
                ["ACARO VERMELHO"] = ["ACARO-VERMELHO", "ACARO_VERMELHO"],
                ["ACARO LEPROSE"] = ["ACARO-LEPROSE", "ACARO_LEPROSE"],
                ["DEF MAGNESIO"] = ["DEFICIENCIA MAGNESIO", "MAGNESIO", "DEF_MAGNESIO"],
                ["DEF FERRO"] = ["DEFICIENCIA FERRO", "FERRO", "DEF_FERRO"],
                ["DEF BORO"] = ["DEFICIENCIA BORO", "BORO", "DEF_BORO"],
                ["DEF COBRE"] = ["DEFICIENCIA COBRE", "COBRE", "DEF_COBRE"],
                ["DEF ZINCO"] = ["DEFICIENCIA ZINCO", "ZINCO", "DEF_ZINCO"],
                ["DEF MANGANES"] = ["DEFICIENCIA MANGANES", "MANGANES", "DEF_MANGANES"],
                ["INTOXICACAO GLIFOSATO"] = ["GLIFOSATO", "INTOXICACAO_GLIFOSATO"],
                ["ANTRAQUINOSE"] = ["ANTRACNOSE"],
                ["ANTRACNOSE"] = ["ANTRAQUINOSE"]
            };
        }

        private static bool IsClassMatch(string expected, string diagnostic)
        {
            if (string.IsNullOrEmpty(expected) || string.IsNullOrEmpty(diagnostic))
                return false;

            // Verifica correspondência direta
            if (diagnostic.Contains(expected))
                return true;

            // Verifica mapeamentos alternativos
            var mappings = CreateClassMappings();
            if (mappings.TryGetValue(expected, out var alternatives))
            {
                return alternatives.Any(alt => diagnostic.Contains(alt));
            }

            // Verifica se o diagnóstico tem mapeamentos que correspondem ao esperado
            foreach (var mapping in mappings)
            {
                if (mapping.Value.Contains(expected) && diagnostic.Contains(mapping.Key))
                    return true;
            }

            return false;
        }

        public JsonArray GenerateReports(JsonArray DiagnosticsJson)
        {
            int total = DiagnosticsJson.Count;
            int acertos = 0, erros = 0;
            int pos1 = 0, pos2 = 0, pos3 = 0;
            Dictionary<string, int> acertosPorClasse = [];
            Dictionary<string, int> totalPorClasse = [];
            List<string> detalhesErros = [];

            foreach (var item in DiagnosticsJson)
            {
                var idRaw = item?["id"]?.ToString() ?? "";
                var responses = item?["response"]?.AsArray();
                if (responses == null || responses.Count == 0) continue;

                // Normaliza o ID da classe esperada
                var expected = NormalizeClassname(idRaw);

                // Conta total por classe
                if (totalPorClasse.ContainsKey(expected))
                    totalPorClasse[expected]++;
                else
                    totalPorClasse[expected] = 1;

                bool acertou = false;
                int numberResponses = Math.Min(3, responses.Count);

                for (int i = 0; i < numberResponses; i++)
                {
                    var diagGPT = responses[i]?["diagnostic"]?.ToString()?.Trim().ToUpper() ?? "";

                    if (IsClassMatch(expected, diagGPT))
                    {
                        acertou = true;

                        if (i == 0) pos1++;
                        else if (i == 1) pos2++;
                        else if (i == 2) pos3++;

                        if (acertosPorClasse.ContainsKey(expected))
                            acertosPorClasse[expected]++;
                        else
                            acertosPorClasse[expected] = 1;

                        break;
                    }
                }

                if (acertou)
                    acertos++;
                else
                {
                    erros++;
                    // Adiciona detalhes do erro para debug
                    var diagsFound = string.Join(", ",
                        responses.Take(numberResponses)
                        .Select(r => r?["diagnostic"]?.ToString() ?? ""));
                    detalhesErros.Add($"ID: {idRaw} | Esperado: {expected} | Encontrado: {diagsFound}");
                }
            }

            double pAcerto = total > 0 ? acertos * 100.0 / total : 0;
            double pErro = total > 0 ? erros * 100.0 / total : 0;
            double pPos1 = total > 0 ? pos1 * 100.0 / total : 0;
            double pPos2 = total > 0 ? pos2 * 100.0 / total : 0;
            double pPos3 = total > 0 ? pos3 * 100.0 / total : 0;

            // Cria o JsonObject dos acertos por classe com precisão por classe
            var acertosClasseJson = new JsonObject();
            var precisaoPorClasse = new JsonObject();

            foreach (var classe in totalPorClasse.Keys)
            {
                int acertosClasse = acertosPorClasse.GetValueOrDefault(classe, 0);
                int totalClasse = totalPorClasse[classe];
                double precisaoClasse = totalClasse > 0 ? acertosClasse * 100.0 / totalClasse : 0;

                acertosClasseJson[classe] = $"{acertosClasse}/{totalClasse}";
                precisaoPorClasse[classe] = $"{precisaoClasse:F2}%";
            }

            var report = new JsonArray
            {
                new JsonObject
                {
                    ["total"] = total,
                    ["acertos"] = acertos,
                    ["erros"] = erros,
                    ["acertos_pos1"] = pos1,
                    ["acertos_pos2"] = pos2,
                    ["acertos_pos3"] = pos3,

                    ["% acertos"] = $"{pAcerto:F2}%",
                    ["% erros"] = $"{pErro:F2}%",
                    ["% acertos_pos1"] = $"{pPos1:F2}%",
                    ["% acertos_pos2"] = $"{pPos2:F2}%",
                    ["% acertos_pos3"] = $"{pPos3:F2}%",

                    ["acertos_por_classe"] = acertosClasseJson,
                    ["precisao_por_classe"] = precisaoPorClasse,
                    ["detalhes_erros"] = new JsonArray([.. detalhesErros.Select(e => JsonValue.Create(e))]) // Primeiros 10 erros
                }
            };

            // Salva o relatório em arquivo JSON
            SaveReportToFile(report);

            return report;
        }

        private void SaveReportToFile(JsonArray report)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string filename = $"metrics_report_{timestamp}.json";
                string filepath = Path.Combine("C:/Users/carlos/Documents/GITHUB/Gestao-Agricola/HandsOn-Back/src/Application/module/IA/reports", filename);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string jsonString = JsonSerializer.Serialize(report, options);
                File.WriteAllText(filepath, jsonString, System.Text.Encoding.UTF8);

                Console.WriteLine($"Relatório salvo em: {filepath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar relatório: {ex.Message}");
            }
        }
    }
}