using Core.Entities;
using Core.Repositories;
using Application.ViewModels;
using Application.Exceptions;
using Application.Validators;
using Application.InputModels.FarmModels;
using System.Security.Claims;
namespace Application.Services
{
    public class FarmServices(IFarmRepository farmRepository) : IFarmServices
    {
        private readonly IFarmRepository _farmRepository = farmRepository;

        public async Task<FarmViewModel> GetByIdAsync(Guid id)
        {
            var farm = await _farmRepository.GetByIdAsync(id) ?? throw new NotFoundException("Farm not found");
            return FarmViewModel.FromEntity(farm);
        }

        public async Task<IEnumerable<FarmViewModel>> GetAllByUserIdAsync(ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            
            var farms = await _farmRepository.GetAllByUserIdAsync(userId);
            return farms.Select(FarmViewModel.FromEntity);
        }

        public async Task<FarmViewModel> CreateAsync(CreateFarmInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var farm = new Farm
            {
                UserId = inputModel.UserId,
                Name = inputModel.Name,
                Location = inputModel.Location
            };

            await _farmRepository.AddAsync(farm);
            return FarmViewModel.FromEntity(farm);
        }

        public async Task<FarmViewModel> UpdateAsync(Guid id, UpdateFarmInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var farm = await _farmRepository.GetByIdAsync(id) ?? throw new NotFoundException("Farm not found");

            farm.Update(
                inputModel.Name,
                inputModel.Location,
                inputModel.UserId
            );

            await _farmRepository.UpdateAsync(farm);
            return FarmViewModel.FromEntity(farm);
        }

        public async Task<FarmViewModel> DeleteAsync(Guid id)
        {
            var farm = await _farmRepository.GetByIdAsync(id) ?? throw new NotFoundException("Farm not found");
            await _farmRepository.DeleteAsync(farm);
            return FarmViewModel.FromEntity(farm);
        }
    }
}