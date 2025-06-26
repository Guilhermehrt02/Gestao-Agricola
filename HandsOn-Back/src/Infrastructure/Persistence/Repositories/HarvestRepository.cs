using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class HarvestRepository(UsersDbContext context) : IHarvestRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<Harvest?> GetByIdAsync(Guid userId, Guid harvestId)
        {
            return await _context.Harvests
                .Where(h => h.Id == harvestId)
                .FirstOrDefaultAsync();
        }

        public async Task<Harvest> AddAsync(Harvest harvest)
        {
            var result = await _context.Harvests.AddAsync(harvest);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Harvest> UpdateAsync(Harvest harvest)
        {
            var result = _context.Harvests.Update(harvest);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Harvest> DeleteAsync(Harvest harvest)
        {
            var result = _context.Harvests.Remove(harvest);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}