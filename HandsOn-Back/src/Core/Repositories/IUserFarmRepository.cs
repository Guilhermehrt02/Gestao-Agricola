using Core.Entities;

namespace Core.Repositories
{
    public interface IUserFarmRepository
    {
        Task<UserFarm?> GetByIdAsync(Guid id);
        Task<IEnumerable<UserFarm>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<UserFarm>> GetByFarmIdAsync(Guid farmId);
        Task<UserFarm> AddAsync(UserFarm userFarm);
        Task<UserFarm> UpdateAsync(UserFarm userFarm);
        Task<UserFarm> DeleteAsync(UserFarm userFarm);
        Task<UserFarm?> DeleteByUserIdAsync(Guid userId);
        Task<UserFarm?> DeleteByFarmIdAsync(Guid farmId);
    }
}