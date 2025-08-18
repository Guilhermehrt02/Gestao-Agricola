using System.Data;
using Core.Enums;

namespace Core.Entities
{
    public class UserFarm
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid FarmId { get; set; }
        public Farm? Farm { get; set; }
        public UserRole? UserRole { get; set; }

        public UserFarm() { }

        public UserFarm(Guid userId, User user, Guid farmId, Farm farm, string userRole)
        {
            UserId = userId;
            User = user;
            FarmId = farmId;
            Farm = farm;
            UserRole = RoleExtension.ToRole(userRole);
        }

        public void Update(string? userRole)
        {
            UserRole = RoleExtension.ToRole(userRole ?? UserRole.ToFriendlyString());
        }

    }
}