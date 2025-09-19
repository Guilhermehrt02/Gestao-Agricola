using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class UserFarmRepository(UsersDbContext context) : IUserFarmRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<UserFarm?> GetByIdAsync(Guid id)
        {
            return await _context.UserFarms
                .Include(uf => uf.User)
                .Include(uf => uf.Farm)
                .Where(uf => uf.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserFarm>> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserFarms
                .Include(uf => uf.User)
                .Include(uf => uf.Farm)
                .Where(uf => uf.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserFarm>> GetByFarmIdAsync(Guid farmId)
        {
            return await _context.UserFarms
                .Include(uf => uf.User)
                .Include(uf => uf.Farm)
                .Where(uf => uf.FarmId == farmId)
                .ToListAsync();
        }

        public async Task<UserFarm> AddAsync(UserFarm userFarm)
        {
            var result = await _context.UserFarms.AddAsync(userFarm);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserFarm> UpdateAsync(UserFarm userFarm)
        {
            var result = _context.UserFarms.Update(userFarm);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserFarm> DeleteAsync(UserFarm userFarm)
        {
            var result = _context.UserFarms.Remove(userFarm);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserFarm?> DeleteByUserIdAsync(Guid userId)
        {
            var userFarm = await _context.UserFarms
                .Where(uf => uf.UserId == userId)
                .FirstOrDefaultAsync();

            if (userFarm == null) return null;

            var result = _context.UserFarms.Remove(userFarm);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserFarm?> DeleteByFarmIdAsync(Guid farmId)
        {
            var userFarm = await _context.UserFarms
                .Where(uf => uf.FarmId == farmId)
                .FirstOrDefaultAsync();

            if (userFarm == null) return null;

            var result = _context.UserFarms.Remove(userFarm);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}