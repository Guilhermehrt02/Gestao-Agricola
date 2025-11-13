using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class FarmRepository(UsersDbContext context) : IFarmRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<Farm?> GetByIdAsync(Guid farmId)
        {
            return await _context.Farms
                .Include(f => f.LocationShapes)
                    .ThenInclude(ls => ls.Coordinates)
                .Where(f => f.Id == farmId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Farm>> GetAllByUserIdAsync(Guid userId)
        {
            return await _context.Farms
                .Include(f => f.LocationShapes)
                    .ThenInclude(ls => ls.Coordinates)
                .Where(f => f.UserId == userId)
                .ToListAsync();
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

        public async Task DeleteLocationShapesByFarmIdAsync(Guid farmId)
        {
            var locationShapes = _context.LocationShapes.Where(ls => ls.FarmId == farmId);
            _context.LocationShapes.RemoveRange(locationShapes);
            await _context.SaveChangesAsync();
        }
    }
}