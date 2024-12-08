// Repositories/Implementations/ScientificDataRepository.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Data;
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Implementations
{
    public class ScientificDataRepository : Repository<ScientificData>, IScientificDataRepository
    {
        public ScientificDataRepository(SpaceResearchContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ScientificData>> GetScientificDataByMissionAsync(int missionId)
        {
            return await _dbSet
                .Include(sd => sd.Mission)
                .Include(sd => sd.Researcher)
                .Where(sd => sd.MissionId == missionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ScientificData>> GetScientificDataByResearcherAsync(int researcherId)
        {
            return await _dbSet
                .Include(sd => sd.Mission)
                .Include(sd => sd.Researcher)
                .Where(sd => sd.ResearcherId == researcherId)
                .ToListAsync();
        }
    }
}
