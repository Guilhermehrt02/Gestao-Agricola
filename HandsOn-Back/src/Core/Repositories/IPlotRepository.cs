using Core.Entities;

namespace Core.Repositories
{
    public interface IPlotRepository
    {
        Task<Plot?> GetByIdAsync(Guid userId, Guid plotId);
        Task<Plot> AddAsync(Plot plot);
        Task<Plot> UpdateAsync(Plot plot);
        Task<Plot> DeleteAsync(Plot plot);
    }
}