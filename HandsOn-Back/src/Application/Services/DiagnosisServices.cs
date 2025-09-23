using Core.Entities;
using Core.Repositories;
using Application.InputModels.DiagnosisModels;
using Application.Exceptions;
using Application.Validators;
using Application.ViewModels.DiagnosisModels;
using Core.Enums;
using System.Security.Claims;
using Infrastructure.Persistence.Migrations;

namespace Application.Services
{
    public class DiagnosisServices(IDiagnosisRepository diagnosisRepository,
        IUploadServices uploadServices,
        IFarmRepository farmRepository,
        IHarvestRepository harvestRepository,
        IPlotRepository plotRepository,
        IAIServiceClient aiServiceClient,
        IDiseaseService diseaseService,
        IDiseaseRepository diseaseRepository) : IDiagnosisServices
    {
        private readonly IDiagnosisRepository _diagnosisRepository = diagnosisRepository;
        private readonly IFarmRepository _farmRepository = farmRepository;
        private readonly IHarvestRepository _harvestRepository = harvestRepository;
        private readonly IPlotRepository _plotRepository = plotRepository;
        private readonly IAIServiceClient _aiServiceClient = aiServiceClient;
        private readonly IUploadServices _uploadServices = uploadServices;
        private readonly IDiseaseService _diseaseService = diseaseService;
        private readonly IDiseaseRepository _diseaseRepository = diseaseRepository;

        public async Task<DiagnosisViewModel> GetByIdAsync(Guid id)
        {
            var diagnosis = await _diagnosisRepository.GetByIdAsync(id) ?? throw new NotFoundException("Diagnosis not found");
            return DiagnosisViewModel.FromEntity(diagnosis);
        }

        public async Task<IEnumerable<DiagnosisViewModel>> GetAllByUserIdAsync(Guid userId)
        {
            var diagnosis = await _diagnosisRepository.GetAllByUserIdAsync(userId);
            return diagnosis.Select(DiagnosisViewModel.FromEntity);
        }

        public async Task<IEnumerable<DiagnosisViewModel>> GetAllByFarmIdsAsync(IEnumerable<Guid> farmIds)
        {
            var diagnoses = await _diagnosisRepository.GetAllByFarmIdsAsync(farmIds);
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
                FarmId = inputModel.FarmId,
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

            await UpdateResult(diagnosis);

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
                await UpdateResult(diagnosis);
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

        public async Task UpdateResult(Diagnosis diagnosis)
        {
            if (diagnosis.Result != null)
            {
                await _diagnosisRepository.DeleteDiagnosisResultByDiagnosisIdAsync(diagnosis.Id);
            }
            //var results = await _aiServiceClient.StartProcessingAsync(diagnosis.Id, diagnosis.PhotoUrl);
            var results = new List<dynamic>
            {
                new { ImagesBook = "acaro branco", Similarity = 0.74 },
                new { ImagesBook = "crisalida", Similarity = 0.7 },
                new { ImagesBook = "bicho mineiro", Similarity = 0.71 }
            };
            if (results != null && results.Count > 0)
            {
                var similarities = new List<ImageSimilarity>();

                foreach (var r in results.OrderByDescending(r => r.Similarity))
                {
                    var diseaseEntity = await _diseaseService.GetByNameAsync(r.ImagesBook);
                    var disease = diseaseEntity != null
                        ? await _diseaseRepository.GetByIdAsync(diseaseEntity.Id)
                        : null;

                    similarities.Add(new ImageSimilarity
                    {
                        ImageBook = r.ImagesBook,
                        Similarity = r.Similarity,
                        DiseaseId = diseaseEntity?.Id,
                        Disease = disease
                    });
                }


                var diagnosisResult = new DiagnosisResult
                {
                    DiagnosisId = diagnosis.Id,
                    Similarities = similarities.ToList()
                };

                await _diagnosisRepository.AddDiagnosisResultAsync(diagnosisResult);

                diagnosis.UpdateResult(diagnosisResult);

                await _diagnosisRepository.UpdateAsync(diagnosis);
            }
        }

        public async Task<DiagnosisViewModel> TestUpdateResult(Guid diagnosisId, List<UpdateDiagnosisResultInputModel> results)
        {
            if (results != null && results.Count > 0)
            {
                var diagnosisResult = new DiagnosisResult
                {
                    DiagnosisId = diagnosisId,
                    Similarities = results
                        .OrderByDescending(r => r.Similarity)
                        .Select((r, index) => new ImageSimilarity
                        {
                            ImageBook = r.ImagesBook,
                            Similarity = r.Similarity,
                        }).ToList()
                };

                await _diagnosisRepository.AddDiagnosisResultAsync(diagnosisResult);

                var diagnosis = await _diagnosisRepository.GetByIdAsync(diagnosisId);
                if (diagnosis != null)
                {
                    diagnosis.UpdateResult(diagnosisResult);
                    var updatedDiagnosis = await _diagnosisRepository.UpdateAsync(diagnosis);
                    return DiagnosisViewModel.FromEntity(updatedDiagnosis);
                }
            }
            return null;
        }
    }
}