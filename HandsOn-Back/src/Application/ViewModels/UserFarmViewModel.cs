using Core.Entities;
using Core.Enums;

namespace Application.ViewModels
{
    public class UserFarmViewModel
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserRole { get; set; } = "Collaborator";
        public Guid FarmId { get; set; }
        public string? UserName { get; set; }
        public string? FarmName { get; set; }

        public static UserFarmViewModel FromEntity(UserFarm userFarm)
        {
            return new UserFarmViewModel
            {
                Id = userFarm.Id,
                UserId = userFarm.UserId,
                FarmId = userFarm.FarmId,
                UserName = userFarm.User?.FullName,
                FarmName = userFarm.Farm?.Name,
                UserRole = userFarm.UserRole?.ToFriendlyString()
            };
        }
    }
}