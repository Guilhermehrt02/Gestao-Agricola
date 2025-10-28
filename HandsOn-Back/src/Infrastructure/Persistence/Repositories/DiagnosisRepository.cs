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
                .Include(x => x.Farm)
                .Include(x => x.Harvest)
                .Include(x => x.Plot)
                .Include(x => x.LocationShapes)
                    .ThenInclude(ls => ls.Coordinates)
                .Include(x => x.Result)
                    .ThenInclude(dr => dr.Similarities)
                        .ThenInclude(s => s.Disease)
                .Where(d => _context.UserFarms
                    .Where(uf => uf.UserId == userId)
                    .Select(uf => uf.FarmId)
                    .Contains(d.FarmId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Diagnosis>> GetAllByFarmIdsAsync(IEnumerable<Guid> farmIds)
        {
            return await _context.Diagnoses
                .Include(x => x.Farm)
                .Include(x => x.Harvest)
                .Include(x => x.Plot)
                .Include(x => x.LocationShapes)
                    .ThenInclude(ls => ls.Coordinates)
                .Include(x => x.Result)
                    .ThenInclude(dr => dr.Similarities)
                        .ThenInclude(s => s.Disease)
                .Join(farmIds, d => d.FarmId, fId => fId, (d, fId) => d)
                .ToListAsync();
        }

        public async Task<Diagnosis?> GetByIdAsync(Guid diagnosisId)
        {
            return await _context.Diagnoses
                .Include(x => x.Farm)
                .Include(x => x.Harvest)
                .Include(x => x.Plot)
                .Include(x => x.LocationShapes)
                    .ThenInclude(ls => ls.Coordinates)
                .Include(x => x.Result)
                    .ThenInclude(dr => dr.Similarities)
                        .ThenInclude(s => s.Disease)
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

        public async Task DeleteLocationShapesByDiagnosisIdAsync(Guid diagnosisId)
        {
            var shapes = _context.LocationShapes.Where(ls => ls.DiagnosisId == diagnosisId);
            _context.LocationShapes.RemoveRange(shapes);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDiagnosisResultByDiagnosisIdAsync(Guid diagnosisId)
        {
            var result = await _context.DiagnosisResults
                .Where(dr => dr.DiagnosisId == diagnosisId)
                .FirstOrDefaultAsync();

            if (result != null)
            {
                _context.DiagnosisResults.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddDiagnosisResultAsync(DiagnosisResult diagnosisResult)
        {
            await _context.DiagnosisResults.AddAsync(diagnosisResult);
            await _context.SaveChangesAsync();
        }
    }
}