using Application.ViewModels;
using Application.InputModels.PlotModels;

namespace Application.Services
{
    public interface IPlotServices
    {
        Task<PlotViewModel> GetByIdAsync(Guid id);
        Task<IEnumerable<PlotViewModel>> GetAllByFarmIdAsync(Guid farmId);
        Task<PlotViewModel> CreateAsync(CreatePlotInputModel inputModel);
        Task<PlotViewModel> UpdateAsync(Guid id, UpdatePlotInputModel inputModel);
        Task<PlotViewModel> DeleteAsync(Guid id);
    }
}