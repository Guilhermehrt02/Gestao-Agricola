using Application.ViewModels;
using Application.InputModels.FarmModels;

namespace Application.Services
{
    public interface IFarmServices
    {
        Task<FarmViewModel> GetByIdAsync(Guid id);
        Task<IEnumerable<FarmViewModel>> GetAllByUserIdAsync(Guid userId);
        Task<FarmViewModel> CreateAsync(CreateFarmInputModel inputModel);
        Task<FarmViewModel> UpdateAsync(Guid id, UpdateFarmInputModel inputModel);
        Task<FarmViewModel> DeleteAsync(Guid id);
    }
}