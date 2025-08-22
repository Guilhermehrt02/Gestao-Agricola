using Application.ViewModels;
using Application.InputModels.UserFarmModels;
using System.Security.Claims;

namespace Application.Services
{
    public interface IUserFarmServices
    {
        Task<UserFarmViewModel> GetByIdAsync(Guid id);
        Task<IEnumerable<UserFarmViewModel>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<UserFarmViewModel>> GetByFarmIdAsync(Guid farmId);
        Task<UserFarmViewModel> CreateAsync(CreateUserFarmInputModel inputModel);
        Task<UserFarmViewModel> UpdateAsync(Guid id, UpdateUserFarmInputModel inputModel);
        Task<UserFarmViewModel> DeleteAsync(Guid id);
    }
}