using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class DiagnosisRepository(UsersDbContext context) : IDiagnosisRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<IEnumerable<Diagnosis>> GetAllByUserIdAsync(Guid userId)
        {
            return await _context.Diagnoses
                .Where(d => d.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Diagnosis>> GetAllByFarmIdAsync(Guid farmId)
        {
            return await _context.Diagnoses
                .Where(d => d.FarmId == farmId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Diagnosis>> GetAllByPlotIdAsync(Guid plotId)
        {
            return await _context.Diagnoses
                .Where(d => d.PlotId == plotId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Diagnosis>> GetAllByHarvestIdAsync(Guid harvestId)
        {
            return await _context.Diagnoses
                .Where(d => d.HarvestId == harvestId)
                .ToListAsync();
        }

        public async Task<Diagnosis?> GetByIdAsync(Guid diagnosisId)
        {
            return await _context.Diagnoses
                .Where(d => d.Id == diagnosisId)
                .FirstOrDefaultAsync();
        }

        public async Task<Diagnosis> AddAsync(Diagnosis diagnosis)
        {
            var result = await _context.Diagnoses.AddAsync(diagnosis);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Diagnosis> UpdateAsync(Diagnosis diagnosis)
        {
            var result = _context.Diagnoses.Update(diagnosis);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Diagnosis> DeleteAsync(Diagnosis diagnosis)
        {
            var result = _context.Diagnoses.Remove(diagnosis);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}