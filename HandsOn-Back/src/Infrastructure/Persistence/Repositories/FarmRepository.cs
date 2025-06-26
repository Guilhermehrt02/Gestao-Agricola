using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class FarmRepository(UsersDbContext context) : IFarmRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<Farm?> GetByIdAsync(Guid userId, Guid farmId)
        {
            return await _context.Farms
                .Where(f => f.Id == farmId && f.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<Farm> AddAsync(Farm farm)
        {
            var result = await _context.Farms.AddAsync(farm);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Farm> UpdateAsync(Farm farm)
        {
            var result = _context.Farms.Update(farm);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Farm> DeleteAsync(Farm farm)
        {
            var result = _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}