namespace Core.Enums
{
    public enum DiagnosisStatus
    {
        Pending,
        Processed,
        Error
    }

    public static class DiagnosisStatusExtension
    {
        public static string ToFriendlyString(this DiagnosisStatus status)
        {
            return status switch
            {
                DiagnosisStatus.Pending => "Pending",
                DiagnosisStatus.Processed => "Processed",
                DiagnosisStatus.Error => "Error",
                _ => "Unknown"
            };
        }

        public static DiagnosisStatus ToDiagnosisStatus(this string status)
        {
            return status.Replace(" ", "") switch
            {
                "Pending" => DiagnosisStatus.Pending,
                "Processed" => DiagnosisStatus.Processed,
                "Error" => DiagnosisStatus.Error,
                _ => DiagnosisStatus.Pending
            };
        }

        public static DiagnosisStatus[] GetValues()
        {
            return [DiagnosisStatus.Pending, DiagnosisStatus.Processed, DiagnosisStatus.Error];
        }
    }
}