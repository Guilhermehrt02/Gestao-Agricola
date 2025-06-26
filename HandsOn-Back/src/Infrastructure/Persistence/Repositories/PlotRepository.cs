using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class PlotRepository(UsersDbContext context) : IPlotRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<Plot?> GetByIdAsync(Guid userId, Guid plotId)
        {
            return await _context.Plots
                .Where(p => p.Id == plotId)
                .FirstOrDefaultAsync();
        }

        public async Task<Plot> AddAsync(Plot plot)
        {
            var result = await _context.Plots.AddAsync(plot);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Plot> UpdateAsync(Plot plot)
        {
            var result = _context.Plots.Update(plot);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Plot> DeleteAsync(Plot plot)
        {
            var result = _context.Plots.Remove(plot);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}