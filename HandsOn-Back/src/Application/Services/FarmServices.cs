using Core.Entities;
using Core.Repositories;
using Application.ViewModels;
using Application.Exceptions;
using Application.Validators;
using Application.InputModels.FarmModels;
using Application.InputModels.UserFarmModels;
using System.Security.Claims;
namespace Application.Services
{
    public class FarmServices(IFarmRepository farmRepository, IUserFarmServices userFarmServices) : IFarmServices
    {
        private readonly IFarmRepository _farmRepository = farmRepository;
        private readonly IUserFarmServices _userFarmServices = userFarmServices;

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

        public async Task<FarmViewModel> CreateAsync(ClaimsPrincipal actionUser, CreateFarmInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            var farm = new Farm
            {
                UserId = userId,
                Name = inputModel.Name,
                Location = inputModel.Location
            };

            await _farmRepository.AddAsync(farm);
            
            await _userFarmServices.CreateAsync(new CreateUserFarmInputModel
            {
                FarmId = farm.Id,
                UserId = userId,
                UserRole = "Owner"
            });

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

            await _userFarmServices.DeleteAsync(farm.Id);
            await _farmRepository.DeleteAsync(farm);
            return FarmViewModel.FromEntity(farm);
        }
    }
}