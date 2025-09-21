

using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace Application.Module.IA
{
    public interface IMetrics
    {
        JsonArray GenerateReports(JsonArray data);
        JsonArray GenerateCharts(JsonArray report);
    }

    public partial class Metrics : IMetrics
    {
        [GeneratedRegex(@"\s*\(.*\)|\d")]
        private static partial Regex MyRegex();

        public JsonArray GenerateCharts(JsonArray report)
        {
            if (report == null || report.Count == 0 || report[0] == null)
                return report ?? [];

            var obj = report[0]!.AsObject();

            // Extrair dados de forma mais robusta
            int total = ExtractIntValue(obj, "total", 0);
            int acertos = ExtractIntValue(obj, "acertos", 0);
            int erros = ExtractIntValue(obj, "erros", 0);
            int acertosPos1 = ExtractIntValue(obj, "acertos_pos1", 0);
            int acertosPos2 = ExtractIntValue(obj, "acertos_pos2", 0);
            int acertosPos3 = ExtractIntValue(obj, "acertos_pos3", 0);

            if (total == 0) return report;

            try
            {
                string chartsDirectory = "C:/Users/carlos/Documents/GITHUB/Gestao-Agricola/HandsOn-Back/src/Application/module/IA/charts";
                Directory.CreateDirectory(chartsDirectory); // Cria se não existir
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                var chartPaths = new List<string>();

                // 1) PIZZA - Performance Geral
                try
                {
                    var pltPie = new ScottPlot.Plot();
                    double[] pieValues = { acertos, erros };

                    var pie = pltPie.Add.Pie(pieValues);
                    pie.Slices[0].FillColor = ScottPlot.Color.FromHex("#28A745");
                    pie.Slices[1].FillColor = ScottPlot.Color.FromHex("#DC3545");
                    pie.Slices[0].Label = $"Acertos: {acertos}";
                    pie.Slices[1].Label = $"Erros: {erros}";

                    foreach (var slice in pie.Slices)
                    {
                        slice.LabelStyle.FontSize = 12;
                        slice.LabelStyle.Bold = true;
                    }

                    pie.ExplodeFraction = 0.1;
                    pltPie.Title($"Performance Geral: {((double)acertos / total * 100):F1}%");

                    string piePath = Path.Combine(chartsDirectory, $"pie_performance_{timestamp}.png");
                    pltPie.SavePng(piePath, 800, 600);
                    chartPaths.Add(piePath);
                    obj["chart_pie"] = JsonValue.Create(piePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro no gráfico pizza: {ex.Message}");
                }

                // 2) BARRAS VERTICAIS - Distribuição Completa
                try
                {
                    var pltBars = new ScottPlot.Plot();

                    double[] positions = { 0, 1, 2, 3 };
                    double[] values = { acertosPos1, acertosPos2, acertosPos3, erros };
                    string[] labels = { "1ª Pos", "2ª Pos", "3ª Pos", "Erros" };

                    var bars = pltBars.Add.Bars(positions, values);

                    // Definir cores individualmente
                    if (bars.Bars.Count >= 4)
                    {
                        bars.Bars[0].FillColor = ScottPlot.Color.FromHex("#28A745"); // Verde
                        bars.Bars[1].FillColor = ScottPlot.Color.FromHex("#6CB33D"); // Verde claro
                        bars.Bars[2].FillColor = ScottPlot.Color.FromHex("#FFC107"); // Amarelo
                        bars.Bars[3].FillColor = ScottPlot.Color.FromHex("#DC3545"); // Vermelho
                    }

                    pltBars.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(positions, labels);
                    pltBars.Title("Distribuição por Categoria");
                    pltBars.Axes.Left.Label.Text = "Quantidade";

                    // Adicionar valores
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (values[i] > 0)
                        {
                            var text = pltBars.Add.Text(values[i].ToString(), positions[i], values[i] + 0.5);
                            text.LabelFontSize = 11;
                            text.LabelBold = true;
                        }
                    }

                    string barsPath = Path.Combine(chartsDirectory, $"bars_distribution_{timestamp}.png");
                    pltBars.SavePng(barsPath, 800, 600);
                    chartPaths.Add(barsPath);
                    obj["chart_bars"] = JsonValue.Create(barsPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro no gráfico de barras: {ex.Message}");
                }

                // 3) BARRAS HORIZONTAIS - Apenas Acertos por Posição
                try
                {
                    if (acertosPos1 + acertosPos2 + acertosPos3 > 0) // Só cria se há acertos
                    {
                        var pltHoriz = new ScottPlot.Plot();

                        double[] yPos = { 0, 1, 2 };
                        double[] xValues = { acertosPos3, acertosPos2, acertosPos1 }; // Invertido
                        string[] yLabels = { "3ª Posição", "2ª Posição", "1ª Posição" };

                        var horizBars = pltHoriz.Add.Bars(yPos, xValues);
                        horizBars.Horizontal = true;

                        if (horizBars.Bars.Count >= 3)
                        {
                            horizBars.Bars[0].FillColor = ScottPlot.Color.FromHex("#FFC107"); // Amarelo
                            horizBars.Bars[1].FillColor = ScottPlot.Color.FromHex("#6CB33D"); // Verde claro  
                            horizBars.Bars[2].FillColor = ScottPlot.Color.FromHex("#28A745"); // Verde
                        }

                        pltHoriz.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(yPos, yLabels);
                        pltHoriz.Title("Acertos por Posição");
                        pltHoriz.Axes.Bottom.Label.Text = "Quantidade de Acertos";

                        string horizPath = Path.Combine(chartsDirectory, $"horizontal_positions_{timestamp}.png");
                        pltHoriz.SavePng(horizPath, 800, 600);
                        chartPaths.Add(horizPath);
                        obj["chart_horizontal"] = JsonValue.Create(horizPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro no gráfico horizontal: {ex.Message}");
                }

                // 4) LINHA - Tendência das Posições
                try
                {
                    var pltLine = new ScottPlot.Plot();

                    double[] xPositions = { 1, 2, 3 };
                    double[] yAcertos = { acertosPos1, acertosPos2, acertosPos3 };

                    var scatter = pltLine.Add.Scatter(xPositions, yAcertos);
                    scatter.Color = ScottPlot.Color.FromHex("#007BFF");
                    scatter.LineWidth = 3;
                    scatter.MarkerSize = 8;

                    pltLine.Title("Tendência de Acertos por Posição");
                    pltLine.Axes.Left.Label.Text = "Número de Acertos";
                    pltLine.Axes.Bottom.Label.Text = "Posição da Tentativa";
                    pltLine.Axes.Bottom.SetTicks(xPositions, new string[] { "1ª", "2ª", "3ª" });

                    // Linha de média
                    if (yAcertos.Length > 0)
                    {
                        double media = yAcertos.Average();
                        var avgLine = pltLine.Add.HorizontalLine(media);
                        avgLine.Color = ScottPlot.Colors.Red;
                        avgLine.LineWidth = 2;
                        avgLine.LinePattern = ScottPlot.LinePattern.Dashed;
                    }

                    string linePath = Path.Combine(chartsDirectory, $"line_trend_{timestamp}.png");
                    pltLine.SavePng(linePath, 800, 600);
                    chartPaths.Add(linePath);
                    obj["chart_line"] = JsonValue.Create(linePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro no gráfico de linha: {ex.Message}");
                }

                // 5) DONUT - Distribuição dos Acertos
                try
                {
                    if (acertosPos1 + acertosPos2 + acertosPos3 > 0)
                    {
                        var pltDonut = new ScottPlot.Plot();

                        double[] donutValues = { acertosPos1, acertosPos2, acertosPos3 };
                        var donut = pltDonut.Add.Pie(donutValues);
                        donut.DonutFraction = 0.6;

                        donut.Slices[0].FillColor = ScottPlot.Color.FromHex("#28A745");
                        donut.Slices[1].FillColor = ScottPlot.Color.FromHex("#6CB33D");
                        donut.Slices[2].FillColor = ScottPlot.Color.FromHex("#FFC107");

                        donut.Slices[0].Label = $"1ª: {acertosPos1}";
                        donut.Slices[1].Label = $"2ª: {acertosPos2}";
                        donut.Slices[2].Label = $"3ª: {acertosPos3}";

                        pltDonut.Title("Distribuição dos Acertos");
                        pltDonut.Axes.Frameless();

                        string donutPath = Path.Combine(chartsDirectory, $"donut_acertos_{timestamp}.png");
                        pltDonut.SavePng(donutPath, 800, 600);
                        chartPaths.Add(donutPath);
                        obj["chart_donut"] = JsonValue.Create(donutPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro no gráfico donut: {ex.Message}");
                }

                // Informações finais
                obj["charts_generated"] = JsonValue.Create(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                obj["total_charts_created"] = JsonValue.Create(chartPaths.Count);
                obj["charts_directory"] = JsonValue.Create(chartsDirectory);

                // Estatísticas
                var stats = CalculateStats(total, acertos, erros, acertosPos1, acertosPos2, acertosPos3);
                foreach (var stat in stats)
                {
                    obj[stat.Key] = JsonValue.Create(stat.Value);
                }

                Console.WriteLine($"✅ {chartPaths.Count} gráficos gerados com sucesso!");
                Console.WriteLine($"📁 Pasta: {chartsDirectory}");
                foreach (var path in chartPaths)
                {
                    Console.WriteLine($"📊 {Path.GetFileName(path)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro geral: {ex.Message}");
                obj["charts_error"] = JsonValue.Create(ex.Message);
            }

            return report;
        }

        // Método auxiliar para extrair valores inteiros
        private static int ExtractIntValue(JsonObject obj, string key, int defaultValue)
        {
            if (obj.TryGetPropertyValue(key, out var node) && node != null)
            {
                var valueStr = node.ToString().Replace("\"", ""); // Remove aspas se houver
                if (int.TryParse(valueStr, out var result))
                    return result;
            }
            return defaultValue;
        }

        // Método para calcular estatísticas
        private static Dictionary<string, object> CalculateStats(int total, int acertos, int erros,
            int pos1, int pos2, int pos3)
        {
            var stats = new Dictionary<string, object>();

            if (total > 0)
            {
                stats["taxa_acerto"] = Math.Round((double)acertos / total * 100, 2);
                stats["taxa_erro"] = Math.Round((double)erros / total * 100, 2);
            }

            int totalAcertos = pos1 + pos2 + pos3;
            if (totalAcertos > 0)
            {
                stats["eficiencia_pos1"] = Math.Round((double)pos1 / totalAcertos * 100, 2);
                stats["eficiencia_pos2"] = Math.Round((double)pos2 / totalAcertos * 100, 2);
                stats["eficiencia_pos3"] = Math.Round((double)pos3 / totalAcertos * 100, 2);
            }

            // Determinar melhor posição
            int melhor = Math.Max(Math.Max(pos1, pos2), pos3);
            if (melhor == pos1) stats["melhor_posicao"] = "Primeira";
            else if (melhor == pos2) stats["melhor_posicao"] = "Segunda";
            else if (melhor == pos3) stats["melhor_posicao"] = "Terceira";
            else stats["melhor_posicao"] = "Nenhuma";

            stats["melhor_valor"] = melhor;

            return stats;
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