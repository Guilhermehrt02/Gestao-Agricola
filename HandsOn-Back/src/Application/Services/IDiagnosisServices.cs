using Application.ViewModels.DiagnosisModels;
using Application.InputModels.DiagnosisModels;
using System.Security.Claims;

namespace Application.Services
{
    public interface IDiagnosisServices
    {
        Task<DiagnosisViewModel> GetByIdAsync(Guid id);
        Task<IEnumerable<DiagnosisViewModel>> GetAllByUserIdAsync(Guid userId);
        Task<DiagnosisViewModel> CreateAsync(ClaimsPrincipal actionUser, CreateDiagnosisInputModel inputModel);
        Task<DiagnosisViewModel> UpdateAsync(Guid id, UpdateDiagnosisInputModel inputModel);
        Task<DiagnosisViewModel> DeleteAsync(Guid id);
        Task<DiagnosisViewModel> TestUpdateResult(Guid diagnosisId, List<UpdateDiagnosisResultInputModel> results);
    }
}