using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Application.Module.Diagnostic
{
    // Interface para o diagnóstico individual
    public interface IDiagnosticResult
    {
        string Id { get; set; }
        string Diagnostic { get; set; }
        string Severity { get; set; }
        string Features { get; set; }
        DateTime Timestamp { get; set; }
    }

    // Interface para a resposta de uma imagem
    public interface IImageDiagnosticResponse
    {
        string Id { get; set; }
        List<IDiagnosticResult> Response { get; set; }
    }
}