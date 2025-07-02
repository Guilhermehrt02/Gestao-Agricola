using Core.Entities;
using Core.Repositories;
using Application.InputModels.DiagnosisModels;
using Application.Exceptions;
using Application.Validators;
using Application.ViewModels;
using Core.Enums;


namespace Application.Services
{
    public class DiagnosisServices(IDiagnosisRepository diagnosisRepository) : IDiagnosisServices
    {
        private readonly IDiagnosisRepository _diagnosisRepository = diagnosisRepository;

        public async Task<DiagnosisViewModel> GetByIdAsync(Guid id)
        {
            var diagnosis = await _diagnosisRepository.GetByIdAsync(id) ?? throw new NotFoundException("Diagnosis not found");
            return DiagnosisViewModel.FromEntity(diagnosis);
        }

        public async Task<IEnumerable<DiagnosisViewModel>> GetAllByUserIdAsync(Guid userId)
        {
            var diagnoses = await _diagnosisRepository.GetAllByUserIdAsync(userId);
            return diagnoses.Select(DiagnosisViewModel.FromEntity);
        }

        public async Task<IEnumerable<DiagnosisViewModel>> GetAllByFarmIdAsync(Guid farmId)
        {
            var diagnoses = await _diagnosisRepository.GetAllByFarmIdAsync(farmId);
            return diagnoses.Select(DiagnosisViewModel.FromEntity);
        }

        public async Task<IEnumerable<DiagnosisViewModel>> GetAllByPlotIdAsync(Guid plotId)
        {
            var diagnoses = await _diagnosisRepository.GetAllByPlotIdAsync(plotId);
            return diagnoses.Select(DiagnosisViewModel.FromEntity);
        }

        public async Task<IEnumerable<DiagnosisViewModel>> GetAllByHarvestIdAsync(Guid harvestId)
        {
            var diagnoses = await _diagnosisRepository.GetAllByHarvestIdAsync(harvestId);
            return diagnoses.Select(DiagnosisViewModel.FromEntity);
        }

        public async Task<DiagnosisViewModel> CreateAsync(CreateDiagnosisInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var diagnosis = new Diagnosis
            {
                UserId = inputModel.UserId,
                FarmId = inputModel.FarmId,
                HarvestId = inputModel.HarvestId,
                PlotId = inputModel.PlotId,
                UploadType = UploadTypeExtension.ToUploadType(inputModel.UploadType),
                PhotoUrl = inputModel.PhotoUrl,
                Date = inputModel.Date,
                Latitude = inputModel.Latitude,
                Longitude = inputModel.Longitude
            };

            await _diagnosisRepository.AddAsync(diagnosis);
            return DiagnosisViewModel.FromEntity(diagnosis);
        }

        public async Task<DiagnosisViewModel> UpdateAsync(Guid id, UpdateDiagnosisInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var diagnosis = await _diagnosisRepository.GetByIdAsync(id) ?? throw new NotFoundException("Diagnosis not found");

            diagnosis.Update(
                inputModel.UploadType,
                inputModel.PhotoUrl,
                inputModel.Date,
                inputModel.FarmId,
                inputModel.UserId,
                inputModel.HarvestId,
                inputModel.PlotId,
                inputModel.Latitude,
                inputModel.Longitude
            );

            await _diagnosisRepository.UpdateAsync(diagnosis);
            return DiagnosisViewModel.FromEntity(diagnosis);
        }

        public async Task<DiagnosisViewModel> DeleteAsync(Guid id)
        {
            var diagnosis = await _diagnosisRepository.GetByIdAsync(id) ?? throw new NotFoundException("Diagnosis not found");
            await _diagnosisRepository.DeleteAsync(diagnosis);
            return DiagnosisViewModel.FromEntity(diagnosis);
        }
    }
}