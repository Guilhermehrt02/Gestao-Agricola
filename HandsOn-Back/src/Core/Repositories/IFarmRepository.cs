using Core.Entities;

namespace Core.Repositories
{
    public interface IFarmRepository
    {
        Task<Farm?> GetByIdAsync(Guid userId, Guid farmId);
        Task<Farm> AddAsync(Farm farm);
        Task<Farm> UpdateAsync(Farm farm);
        Task<Farm> DeleteAsync(Farm farm);
    }
}