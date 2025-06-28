using Core.Entities;

namespace Core.Repositories
{
    public interface IFarmRepository
    {
        Task<Farm?> GetByIdAsync(Guid farmId);
        Task<IEnumerable<Farm>> GetAllByUserIdAsync(Guid userId);
        Task<Farm> AddAsync(Farm farm);
        Task<Farm> UpdateAsync(Farm farm);
        Task<Farm> DeleteAsync(Farm farm);
    }
}