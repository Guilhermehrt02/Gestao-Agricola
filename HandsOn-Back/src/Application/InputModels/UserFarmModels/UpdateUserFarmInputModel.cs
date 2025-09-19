namespace Application.InputModels.UserFarmModels
{
    public class UpdateUserFarmInputModel
    {
        public Guid? UserId { get; set; }

        public Guid? FarmId { get; set; }

        public string? UserRole { get; set; }
    }
}