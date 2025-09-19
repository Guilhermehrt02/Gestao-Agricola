using Application.ViewModels;
using Application.InputModels.FarmModels;
using System.Security.Claims;

namespace Application.Services
{
    public interface IFarmServices
    {
        Task<FarmViewModel> GetByIdAsync(Guid id);
        Task<IEnumerable<FarmViewModel>> GetAllByUserIdAsync(ClaimsPrincipal actionUser);
        Task<FarmViewModel> CreateAsync(ClaimsPrincipal actionUser, CreateFarmInputModel inputModel);
        Task<FarmViewModel> UpdateAsync(Guid id, UpdateFarmInputModel inputModel);
        Task<FarmViewModel> DeleteAsync(Guid id);
    }
}