using Core.Entities;
using Core.Repositories;
using Application.InputModels.UserFarmModels;
using Application.Exceptions;
using Application.Validators;
using Application.ViewModels;
using Core.Enums;
using System.Security.Claims;

namespace Application.Services
{
    public class UserFarmServices(IUserFarmRepository userFarmRepository, IUsersRepository userRepository, IFarmRepository farmRepository) : IUserFarmServices
    {
        private readonly IUserFarmRepository _userFarmRepository = userFarmRepository;
        private readonly IUsersRepository _userRepository = userRepository;
        private readonly IFarmRepository _farmRepository = farmRepository;

        public async Task<UserFarmViewModel> GetByIdAsync(Guid id)
        {
            var userFarm = await _userFarmRepository.GetByIdAsync(id) ?? throw new NotFoundException("UserFarm not found");
            return UserFarmViewModel.FromEntity(userFarm);
        }

        public async Task<IEnumerable<UserFarmViewModel>> GetByUserIdAsync(Guid userId)
        {
            var userFarms = await _userFarmRepository.GetByUserIdAsync(userId);
            return userFarms.Select(UserFarmViewModel.FromEntity);
        }

        public async Task<IEnumerable<UserFarmViewModel>> GetByFarmIdAsync(Guid farmId)
        {
            var userFarms = await _userFarmRepository.GetByFarmIdAsync(farmId);
            return userFarms.Select(UserFarmViewModel.FromEntity);
        }

        public async Task<UserFarmViewModel> CreateAsync(CreateUserFarmInputModel inputModel)
        {
            //var actionUserId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            InputModelValidator.Validate(inputModel);

            var user = await _userRepository.GetByIdAsync(inputModel.UserId) ?? throw new NotFoundException("User not found");
            var farm = await _farmRepository.GetByIdAsync(inputModel.FarmId) ?? throw new NotFoundException("Farm not found");

            var userFarm = new UserFarm
            {
                UserId = inputModel.UserId,
                User = user,
                FarmId = inputModel.FarmId,
                Farm = farm,
                UserRole = RoleExtension.ToRole(inputModel.UserRole ?? "Collaborator")
            };

            await _userFarmRepository.AddAsync(userFarm);

            return UserFarmViewModel.FromEntity(userFarm);
        }

        public async Task<UserFarmViewModel> UpdateAsync(Guid id, UpdateUserFarmInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var userFarm = await _userFarmRepository.GetByIdAsync(id) ?? throw new NotFoundException("UserFarm not found");

            userFarm.Update(inputModel.UserRole ?? "Collaborator");

            await _userFarmRepository.UpdateAsync(userFarm);

            return UserFarmViewModel.FromEntity(userFarm);
        }

        public async Task<UserFarmViewModel> DeleteAsync(Guid id)
        {
            var userFarm = await _userFarmRepository.GetByIdAsync(id) ?? throw new NotFoundException("UserFarm not found");

            await _userFarmRepository.DeleteAsync(userFarm);

            return UserFarmViewModel.FromEntity(userFarm);
        }

    }
}