using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.HarvestModels
{
    public class UpdateHarvestInputModel
    {
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string? Name { get; set; }

        public Guid? FarmId { get; set; }

        public DateTime? StartDate { get; set; }

        [CustomValidation(typeof(UpdateHarvestInputModel), nameof(ValidateEndDate))]
        public DateTime? EndDate { get; set; }

        public static ValidationResult? ValidateEndDate(DateTime? endDate, ValidationContext context)
        {
            if (endDate.HasValue && context.ObjectInstance is UpdateHarvestInputModel inputModel
                && inputModel.StartDate.HasValue && endDate < inputModel.StartDate)
            {
                return new ValidationResult("End date cannot be less than start date.");
            }
            return ValidationResult.Success;
        }
    }
}