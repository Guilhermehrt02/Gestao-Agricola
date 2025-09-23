using Application.InputModels.DiseaseModels;
using Application.ViewModels.DiseaseModels;
namespace Application.Services
{
    public interface IDiseaseService
    {
        Task<DiseaseViewModel> GetByIdAsync(Guid id);
        Task<DiseaseViewModel> GetByNameAsync(string name);
        Task<IEnumerable<DiseaseViewModel>> GetAllAsync();
        Task<DiseaseViewModel> CreateAsync(CreateDiseaseInputModel inputModel);
        Task<DiseaseViewModel> UpdateAsync(Guid id, UpdateDiseaseInputModel inputModel);
        Task<DiseaseViewModel> DeleteAsync(Guid id);
    }
}