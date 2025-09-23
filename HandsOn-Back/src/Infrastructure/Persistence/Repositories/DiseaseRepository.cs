using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class DiseaseRepository(UsersDbContext context) : IDiseaseRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<IEnumerable<Disease>> GetAllAsync()
        {
            return await _context.Diseases.ToListAsync();
        }

        public async Task<Disease?> GetByIdAsync(Guid id)
        {
            return await _context.Diseases.FindAsync(id);
        }

        public async Task<Disease?> GetByNameAsync(string name)
        {
            return await _context.Diseases.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task<Disease> AddAsync(Disease disease)
        {
            var result = await _context.Diseases.AddAsync(disease);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Disease> UpdateAsync(Disease disease)
        {
            var result = _context.Diseases.Update(disease);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Disease> DeleteAsync(Disease disease)
        {
            var result = _context.Diseases.Remove(disease);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
