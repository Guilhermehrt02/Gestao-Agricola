using Core.Entities;
using Core.Repositories;
using Application.ViewModels.DiseaseModels;
using Application.InputModels.DiseaseModels;
using Core.Enums;
using Application.Exceptions;
using Application.Validators;
using Microsoft.AspNetCore.Http;


namespace Application.Services
{
    public class DiseaseService(IDiseaseRepository diseaseRepository, IUploadServices uploadServices, IHttpContextAccessor httpContextAccessor) : IDiseaseService
    {
        private readonly IDiseaseRepository _diseaseRepository = diseaseRepository;
        private readonly IUploadServices _uploadServices = uploadServices;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<DiseaseViewModel> CreateAsync(CreateDiseaseInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            string ReferenceImageUrl = null;

            if (inputModel.ImageFile != null)
            {
                var relativePath = await _uploadServices.UploadFileAsync(inputModel.ImageFile);

                relativePath = relativePath.TrimStart('/');

                var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
                ReferenceImageUrl = $"{baseUrl}/{relativePath}";
            }


            var disease = new Disease
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                Class = UploadTypeExtension.ToUploadType(inputModel.Class),
                ReferenceImageUrl = ReferenceImageUrl ?? string.Empty,
                Symptoms = inputModel.Symptoms ?? string.Empty,
                Prevention = inputModel.Prevention ?? string.Empty,
                Recommendation = inputModel.Recommendation ?? string.Empty
            };

            await _diseaseRepository.AddAsync(disease);

            return DiseaseViewModel.FromEntity(disease);
        }

        public async Task<DiseaseViewModel> DeleteAsync(Guid id)
        {
            var disease = await _diseaseRepository.GetByIdAsync(id);
            if (!string.IsNullOrEmpty(disease.ReferenceImageUrl))
            {
                await _uploadServices.DeleteFileAsync(disease.ReferenceImageUrl);
            }

            await _diseaseRepository.DeleteAsync(disease);

            return DiseaseViewModel.FromEntity(disease);
        }

        public async Task<IEnumerable<DiseaseViewModel>> GetAllAsync()
        {
            var diseases = await _diseaseRepository.GetAllAsync();
            return diseases.Select(DiseaseViewModel.FromEntity);
        }

        public async Task<DiseaseViewModel> GetByIdAsync(Guid id)
        {
            var disease = await _diseaseRepository.GetByIdAsync(id) ?? throw new NotFoundException("Disease not found");
          
            return DiseaseViewModel.FromEntity(disease);
        }
        
        public async Task<DiseaseViewModel> GetByNameAsync(string name)
        {
            var disease = await _diseaseRepository.GetByNameAsync(name) ?? null;
            if (disease == null) return null;
          
            return DiseaseViewModel.FromEntity(disease);
        }

        public async Task<DiseaseViewModel> UpdateAsync(Guid id, UpdateDiseaseInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var disease = await _diseaseRepository.GetByIdAsync(id) ?? throw new NotFoundException("Disease not found");
            var newReferenceImageUrl = disease.ReferenceImageUrl;

            if (inputModel.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(disease.ReferenceImageUrl))
                {
                    await _uploadServices.DeleteFileAsync(disease.ReferenceImageUrl);

                }

                var relativePath = await _uploadServices.UploadFileAsync(inputModel.ImageFile);
                relativePath = relativePath.TrimStart('/');

                var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
                newReferenceImageUrl = $"{baseUrl}/{relativePath}";
            }

            disease.Update(
                inputModel.Name,
                inputModel.Description,
                inputModel.Class,
                newReferenceImageUrl,
                inputModel.Symptoms,
                inputModel.Prevention,
                inputModel.Recommendation
            );

            await _diseaseRepository.UpdateAsync(disease);

            return DiseaseViewModel.FromEntity(disease);
        }
    }
}