using Application.ViewModels;
using Application.InputModels.HarvestModels;

namespace Application.Services
{
    public interface IHarvestServices
    {
        Task<HarvestViewModel> GetByIdAsync(Guid id);
        Task<IEnumerable<HarvestViewModel>> GetAllByFarmIdAsync(Guid farmId);
        Task<HarvestViewModel> CreateAsync(CreateHarvestInputModel inputModel);
        Task<HarvestViewModel> UpdateAsync(Guid id, UpdateHarvestInputModel inputModel);
        Task<HarvestViewModel> DeleteAsync(Guid id);
    }
}