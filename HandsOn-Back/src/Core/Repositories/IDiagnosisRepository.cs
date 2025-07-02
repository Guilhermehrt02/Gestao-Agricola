using Core.Entities;

namespace Core.Repositories
{
    public interface IDiagnosisRepository
    {
        Task<Diagnosis?> GetByIdAsync(Guid diagnosisId);
        Task<IEnumerable<Diagnosis>> GetAllByUserIdAsync(Guid userId);
        Task<IEnumerable<Diagnosis>> GetAllByFarmIdAsync(Guid farmId);
        Task<IEnumerable<Diagnosis>> GetAllByPlotIdAsync(Guid plotId);
        Task<IEnumerable<Diagnosis>> GetAllByHarvestIdAsync(Guid harvestId);
        Task<Diagnosis> AddAsync(Diagnosis diagnosis);
        Task<Diagnosis> UpdateAsync(Diagnosis diagnosis);
        Task<Diagnosis> DeleteAsync(Diagnosis diagnosis);
    }
}