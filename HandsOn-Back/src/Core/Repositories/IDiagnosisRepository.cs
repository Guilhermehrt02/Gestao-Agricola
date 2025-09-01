using Core.Entities;

namespace Core.Repositories
{
    public interface IDiagnosisRepository
    {
        Task<Diagnosis?> GetByIdAsync(Guid diagnosisId);
        Task<IEnumerable<Diagnosis>> GetAllByUserIdAsync(Guid userId);
        Task<IEnumerable<Diagnosis>> GetAllByFarmIdsAsync(IEnumerable<Guid> farmIds);
        Task<Diagnosis> AddAsync(Diagnosis diagnosis);
        Task<Diagnosis> UpdateAsync(Diagnosis diagnosis);
        Task<Diagnosis> DeleteAsync(Diagnosis diagnosis);
        Task DeleteLocationShapesByDiagnosisIdAsync(Guid diagnosisId);
    }
}