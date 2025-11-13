using Core.Entities;
using Core.Repositories;
using Application.ViewModels;
using Application.Exceptions;
using Application.Validators;
using Application.InputModels.PlotModels;

namespace Application.Services
{
    public class PlotServices(IPlotRepository plotRepository) : IPlotServices
    {
        private readonly IPlotRepository _plotRepository = plotRepository;

        public async Task<PlotViewModel> GetByIdAsync(Guid id)
        {
            var plot = await _plotRepository.GetByIdAsync(id) ?? throw new NotFoundException("Plot not found");
            return PlotViewModel.FromEntity(plot);
        }

        public async Task<IEnumerable<PlotViewModel>> GetAllByFarmIdAsync(Guid farmId)
        {
            var plots = await _plotRepository.GetAllByFarmIdAsync(farmId);
            return plots.Select(PlotViewModel.FromEntity);
        }

        public async Task<PlotViewModel> CreateAsync(CreatePlotInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var plot = new Plot
            {
                FarmId = inputModel.FarmId,
                Name = inputModel.Name,
                Description = inputModel.Description,
                Area = inputModel.Area,
                Latitude = inputModel.Latitude,
                Longitude = inputModel.Longitude
            };

            await _plotRepository.AddAsync(plot);
            return PlotViewModel.FromEntity(plot);
        }

        public async Task<PlotViewModel> UpdateAsync(Guid id, UpdatePlotInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var plot = await _plotRepository.GetByIdAsync(id) ?? throw new NotFoundException("Plot not found");

            List<LocationShape>? locationShapes = null;
            if (inputModel.LocationShapes != null && inputModel.LocationShapes.Count > 0)
            {
                await _plotRepository.DeleteLocationShapesByPlotIdAsync(plot.Id);

                locationShapes = inputModel.LocationShapes
                    .Select(ls => new LocationShape
                    {
                        Type = ls.Type,
                        Label = ls.Label,
                        Plot = plot,
                        Coordinates = ls.Coordinates.Select(c => new Coordinate
                        {
                            Lat = c.Lat,
                            Lng = c.Lng
                        }).ToList()
                    }).ToList();
            }

            plot.Update(
                inputModel.Name,
                inputModel.FarmId,
                inputModel.Area,
                inputModel.Description,
                inputModel.Latitude,
                inputModel.Longitude
            );

            await _plotRepository.UpdateAsync(plot);
            return PlotViewModel.FromEntity(plot);
        }

        public async Task<PlotViewModel> DeleteAsync(Guid id)
        {
            var plot = await _plotRepository.GetByIdAsync(id) ?? throw new NotFoundException("Plot not found");
            await _plotRepository.DeleteAsync(plot);
            return PlotViewModel.FromEntity(plot);
        }
    }
}