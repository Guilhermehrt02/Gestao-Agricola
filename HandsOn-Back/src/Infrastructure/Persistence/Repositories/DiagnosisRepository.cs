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

        public async Task<Diagnosis?> GetByIdAsync(Guid userId, Guid diagnosisId)
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