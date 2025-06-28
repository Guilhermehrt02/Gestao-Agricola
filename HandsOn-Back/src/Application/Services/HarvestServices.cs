using Core.Entities;
using Core.Repositories;
using Application.ViewModels;
using Application.Exceptions;
using Application.Validators;
using Application.InputModels.HarvestModels;
using Core.Enums;

namespace Application.Services
{
    public class HarvestServices(IHarvestRepository harvestRepository) : IHarvestServices
    {
        private readonly IHarvestRepository _harvestRepository = harvestRepository;

        public async Task<HarvestViewModel> GetByIdAsync(Guid id)
        {
            var harvest = await _harvestRepository.GetByIdAsync(id) ?? throw new NotFoundException("Harvest not found");
            return HarvestViewModel.FromEntity(harvest);
        }

        public async Task<IEnumerable<HarvestViewModel>> GetAllByFarmIdAsync(Guid farmId)
        {
            var harvests = await _harvestRepository.GetAllByFarmIdAsync(farmId);
            return harvests.Select(HarvestViewModel.FromEntity);
        }

        public async Task<HarvestViewModel> CreateAsync(CreateHarvestInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var harvest = new Harvest
            {
                FarmId = inputModel.FarmId,
                Name = inputModel.Name,
                StartDate = inputModel.StartDate,
                EndDate = inputModel.EndDate,
            };

            await _harvestRepository.AddAsync(harvest);
            return HarvestViewModel.FromEntity(harvest);
        }

        public async Task<HarvestViewModel> UpdateAsync(Guid id, UpdateHarvestInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var harvest = await _harvestRepository.GetByIdAsync(id) ?? throw new NotFoundException("Harvest not found");

            harvest.Update(
                inputModel.Name,
                inputModel.StartDate,
                inputModel.EndDate,
                inputModel.FarmId
            );

            await _harvestRepository.UpdateAsync(harvest);
            return HarvestViewModel.FromEntity(harvest);
        }

        public async Task<HarvestViewModel> DeleteAsync(Guid id)
        {
            var harvest = await _harvestRepository.GetByIdAsync(id) ?? throw new NotFoundException("Harvest not found");
            await _harvestRepository.DeleteAsync(harvest);
            return HarvestViewModel.FromEntity(harvest);
        }
    }
}