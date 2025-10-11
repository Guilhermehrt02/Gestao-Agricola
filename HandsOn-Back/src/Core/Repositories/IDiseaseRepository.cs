using Core.Entities;

namespace Core.Repositories
{
    public interface IDiseaseRepository
    {
        Task<Disease?> GetByIdAsync(Guid id);
        Task<Disease?> GetByNameAsync(string name);
        Task<IEnumerable<Disease>> GetAllAsync();
        Task<Disease> AddAsync(Disease disease);
        Task<Disease> UpdateAsync(Disease disease);
        Task<Disease> DeleteAsync(Disease disease);
    }
}