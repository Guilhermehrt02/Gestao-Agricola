using Core.Entities;
using Core.Repositories;
using Application.InputModels.DiagnosisModels;
using Application.Exceptions;
using Application.Validators;
using Application.ViewModels;
using Core.Enums;
using System.Security.Claims;

namespace Application.Services
{
    public class DiagnosisServices(IDiagnosisRepository diagnosisRepository, IUploadServices uploadServices, IFarmRepository farmRepository, IHarvestRepository harvestRepository, IPlotRepository plotRepository) : IDiagnosisServices
    {
        private readonly IDiagnosisRepository _diagnosisRepository = diagnosisRepository;
        private readonly IFarmRepository _farmRepository = farmRepository;
        private readonly IHarvestRepository _harvestRepository = harvestRepository;
        private readonly IPlotRepository _plotRepository = plotRepository;

        private readonly IUploadServices _uploadServices = uploadServices;

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

        public async Task<DiagnosisViewModel> CreateAsync(ClaimsPrincipal actionUser, CreateDiagnosisInputModel inputModel)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            InputModelValidator.Validate(inputModel);

            var farm = await _farmRepository.GetByIdAsync(inputModel.FarmId) ?? throw new NotFoundException("Farm not found");
            var harvest = await _harvestRepository.GetByIdAsync(inputModel.HarvestId) ?? throw new NotFoundException("Harvest not found");
            var plot = await _plotRepository.GetByIdAsync(inputModel.PlotId) ?? throw new NotFoundException("Plot not found");

            if (harvest.FarmId != farm.Id)
                throw new InvalidOperationException("The selected harvest does not belong to the selected farm.");

            if (plot.FarmId != farm.Id)
                throw new InvalidOperationException("The selected plot does not belong to the selected farm.");

            List<LocationShape> locationShapes = new List<LocationShape>();

            if (inputModel.LocationShapes != null && inputModel.LocationShapes.Count > 0)
            {
                locationShapes = inputModel.LocationShapes.Select(shape => new LocationShape
                {
                    Type = shape.Type,
                    Label = shape.Label,
                    Coordinates = shape.Coordinates.Select(coord => new Coordinate
                    {
                        Lat = coord.Lat,
                        Lng = coord.Lng
                    }).ToList()
                }).ToList();
            }
            
            var diagnosis = new Diagnosis
            {
                UserId = userId,
                Farm = farm,
                Harvest = harvest,
                Plot = plot,
                UploadType = UploadTypeExtension.ToUploadType(inputModel.UploadType),
                PhotoUrl = inputModel.PhotoUrl,
                Date = inputModel.Date,
                Latitude = inputModel.Latitude,
                Longitude = inputModel.Longitude,
                LocationShapes = locationShapes
            };

            await _diagnosisRepository.AddAsync(diagnosis);
            return DiagnosisViewModel.FromEntity(diagnosis);
        }

        public async Task<DiagnosisViewModel> UpdateAsync(Guid id, UpdateDiagnosisInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var diagnosis = await _diagnosisRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException("Diagnosis not found");

            Farm? farm = null;
            Harvest? harvest = null;
            Plot? plot = null;

            if (inputModel.FarmId.HasValue)
            {
                farm = await _farmRepository.GetByIdAsync(inputModel.FarmId.Value)
                       ?? throw new NotFoundException("Farm not found");
            }

            if (inputModel.HarvestId.HasValue)
            {
                harvest = await _harvestRepository.GetByIdAsync(inputModel.HarvestId.Value)
                          ?? throw new NotFoundException("Harvest not found");
            }

            if (inputModel.PlotId.HasValue)
            {
                plot = await _plotRepository.GetByIdAsync(inputModel.PlotId.Value)
                       ?? throw new NotFoundException("Plot not found");
            }

            if (farm != null)
            {
                if (harvest != null && harvest.FarmId != farm.Id)
                    throw new InvalidOperationException("The selected harvest does not belong to the selected farm.");

                if (plot != null && plot.FarmId != farm.Id)
                    throw new InvalidOperationException("The selected plot does not belong to the selected farm.");
            }

            if (!string.IsNullOrEmpty(inputModel.PhotoUrl) &&
                !string.IsNullOrEmpty(diagnosis.PhotoUrl) &&
                inputModel.PhotoUrl != diagnosis.PhotoUrl)
            {
                await _uploadServices.DeleteFileAsync(diagnosis.PhotoUrl);
            }

            List<LocationShape>? locationShapes = null;
            if (inputModel.LocationShapes != null && inputModel.LocationShapes.Count > 0)
            {
                await _diagnosisRepository.DeleteLocationShapesByDiagnosisIdAsync(diagnosis.Id);

                locationShapes = inputModel.LocationShapes.Select(shape => new LocationShape
                {
                    Type = shape.Type,
                    Label = shape.Label,
                    Coordinates = shape.Coordinates.Select(coord => new Coordinate
                    {
                        Lat = coord.Lat,
                        Lng = coord.Lng
                    }).ToList()
                }).ToList();

            }

            diagnosis.Update(
                inputModel.UploadType,
                inputModel.PhotoUrl,
                inputModel.Date,
                farm,
                inputModel.UserId,
                harvest,
                plot,
                inputModel.Latitude,
                inputModel.Longitude,
                locationShapes,
                inputModel.Status
            );

            await _diagnosisRepository.UpdateAsync(diagnosis);
            return DiagnosisViewModel.FromEntity(diagnosis);
        }

        public async Task<DiagnosisViewModel> DeleteAsync(Guid id)
        {
            var diagnosis = await _diagnosisRepository.GetByIdAsync(id) ?? throw new NotFoundException("Diagnosis not found");

            if (!string.IsNullOrEmpty(diagnosis.PhotoUrl))
            {
                await _uploadServices.DeleteFileAsync(diagnosis.PhotoUrl);
            }

            if (diagnosis.LocationShapes != null && diagnosis.LocationShapes.Count > 0)
            {
                await _diagnosisRepository.DeleteLocationShapesByDiagnosisIdAsync(diagnosis.Id);
            }

            await _diagnosisRepository.DeleteAsync(diagnosis);

            return DiagnosisViewModel.FromEntity(diagnosis);
        }
    }
}