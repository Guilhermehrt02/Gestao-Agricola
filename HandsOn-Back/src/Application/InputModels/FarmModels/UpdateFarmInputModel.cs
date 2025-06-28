using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.FarmModels
{
    public class UpdateFarmInputModel
    {
        public Guid? Id { get; set; }

        public Guid? UserId { get; set; }

        [MaxLength(100, ErrorMessage = "Farm name cannot exceed 100 characters.")]
        public string? Name { get; set; } = string.Empty;

        [MaxLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s,.'-]+$", ErrorMessage = "Location can only contain letters, numbers, spaces, commas, periods, and hyphens.")]
        public string? Location { get; set; }
    }
}