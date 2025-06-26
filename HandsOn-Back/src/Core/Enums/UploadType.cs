namespace Core.Enums
{
    public enum UploadType
    {
        Disease,
        Pest,
        Deficiency,
        Other
    }

    public static class UploadTypeExtension
    {
        public static string ToFriendlyString(this UploadType uploadType)
        {
            return uploadType switch
            {
                UploadType.Disease => "Disease",
                UploadType.Pest => "Pest",
                UploadType.Deficiency => "Deficiency",
                UploadType.Other => "Other",
                _ => "Unknown",
            };
        }

        public static UploadType ToUploadType(this string uploadType)
        {
            return uploadType.Replace(" ", "") switch
            {
                "Disease" => UploadType.Disease,
                "Pest" => UploadType.Pest,
                "Deficiency" => UploadType.Deficiency,
                "Other" => UploadType.Other,
                _ => UploadType.Other,
            };
        }

        public static UploadType[] GetValues()
        {
            return [UploadType.Disease, UploadType.Pest, UploadType.Deficiency, UploadType.Other];
        }
    }
}