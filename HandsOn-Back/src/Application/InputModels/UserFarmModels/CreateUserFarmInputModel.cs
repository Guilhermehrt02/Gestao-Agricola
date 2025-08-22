using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.UserFarmModels
{
    public class CreateUserFarmInputModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid FarmId { get; set; }

        public string? UserRole { get; set; }
    }
}