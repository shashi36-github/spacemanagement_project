// Repositories/Implementations/EnvironmentalDataRepository.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Data;
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Implementations
{
    public class EnvironmentalDataRepository : Repository<EnvironmentalData>, IEnvironmentalDataRepository
    {
        public EnvironmentalDataRepository(SpaceResearchContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EnvironmentalData>> GetEnvironmentalAssessmentsByMissionAsync(int missionId)
        {
            return await _dbSet
                .Include(ed => ed.Mission)
                .Where(ed => ed.MissionId == missionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<EnvironmentalData>> GetEnvironmentalAssessmentsByImpactTypeAsync(ImpactType impactType)
        {
            return await _dbSet
                .Include(ed => ed.Mission)
                .Where(ed => ed.ImpactType == impactType)
                .ToListAsync();
        }
    }
}
