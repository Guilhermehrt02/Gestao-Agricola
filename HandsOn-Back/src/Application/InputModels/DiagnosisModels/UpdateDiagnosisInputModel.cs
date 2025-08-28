using Core.Enums;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Application.InputModels.DiagnosisModels
{
    public class UpdateDiagnosisInputModel
    {
        public Guid? UserId { get; set; }
        public Guid? FarmId { get; set; }
        public Guid? HarvestId { get; set; }
        public Guid? PlotId { get; set; }
        public string? UploadType { get; set; }
    
        [Url(ErrorMessage = "Invalid URL format.")]
        public string? PhotoUrl { get; set; }

        [CustomValidation(typeof(UpdateDiagnosisInputModel), nameof(ValidateDate))]
        public DateTime? Date { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90 degrees.")]
        public double? Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180 degrees.")]
        public double? Longitude { get; set; }
        public List<LocationShape>? LocationShapes { get; set; }
        public string? Status { get; set; }

        public static ValidationResult ValidateDate(DateTime? date, ValidationContext context)
        {
            if (date > DateTime.Now)
            {
                return new ValidationResult("Date cannot be in the future.");
            }

            return ValidationResult.Success!;
        }
    }
}