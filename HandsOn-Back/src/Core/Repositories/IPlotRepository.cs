using Core.Entities;

namespace Core.Repositories
{
    public interface IPlotRepository
    {
        Task<Plot?> GetByIdAsync(Guid plotId);
        Task<IEnumerable<Plot>> GetAllByFarmIdAsync(Guid farmId);
        Task<Plot> AddAsync(Plot plot);
        Task<Plot> UpdateAsync(Plot plot);
        Task<Plot> DeleteAsync(Plot plot);
        Task DeleteLocationShapesByPlotIdAsync(Guid plotId);
    }
}