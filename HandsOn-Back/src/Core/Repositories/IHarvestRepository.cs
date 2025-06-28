using Core.Entities;

namespace Core.Repositories
{
    public interface IHarvestRepository
    {
        Task<Harvest?> GetByIdAsync(Guid harvestId);
        Task<IEnumerable<Harvest>> GetAllByFarmIdAsync(Guid farmId);
        Task<Harvest> AddAsync(Harvest harvest);
        Task<Harvest> UpdateAsync(Harvest harvest);
        Task<Harvest> DeleteAsync(Harvest harvest);
    }
}