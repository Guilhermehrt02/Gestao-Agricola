using Application.ViewModels;
using Application.InputModels.DiagnosisModels;
using System.Security.Claims;

namespace Application.Services
{
    public interface IDiagnosisServices
    {
        Task<DiagnosisViewModel> GetByIdAsync(Guid id);
        Task<IEnumerable<DiagnosisViewModel>> GetAllByUserIdAsync(Guid userId);
        Task<IEnumerable<DiagnosisViewModel>> GetAllByFarmIdAsync(Guid farmId);
        Task<IEnumerable<DiagnosisViewModel>> GetAllByPlotIdAsync(Guid plotId);
        Task<IEnumerable<DiagnosisViewModel>> GetAllByHarvestIdAsync(Guid harvestId);
        Task<DiagnosisViewModel> CreateAsync(ClaimsPrincipal actionUser, CreateDiagnosisInputModel inputModel);
        Task<DiagnosisViewModel> UpdateAsync(Guid id, UpdateDiagnosisInputModel inputModel);
        Task<DiagnosisViewModel> DeleteAsync(Guid id);
    }
}