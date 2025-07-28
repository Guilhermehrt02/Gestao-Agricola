using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.DiagnosisModels
{
    public class CreateDiagnosisInputModel
    {
        [Required(ErrorMessage = "FarmId is required.")]
        public Guid FarmId { get; set; }

        [Required(ErrorMessage = "HarvestId is required.")]
        public Guid HarvestId { get; set; }

        [Required(ErrorMessage = "PlotId is required.")]
        public Guid PlotId { get; set; }

        [Required(ErrorMessage = "UploadType is required.")]
        public string UploadType { get; set; } = String.Empty;

        [Required(ErrorMessage = "PhotoUrl is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string PhotoUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date is required.")]
        [CustomValidation(typeof(CreateDiagnosisInputModel), nameof(ValidateDate))]
        public DateTime Date { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90 degrees.")]
        public double? Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180 degrees.")]
        public double? Longitude { get; set; }

        public static ValidationResult ValidateDate(DateTime date, ValidationContext context)
        {
            if (date > DateTime.Now)
            {
                return new ValidationResult("Date cannot be in the future.");
            }

            return ValidationResult.Success!;
        }
    }
}