// Repositories/Implementations/SafetyLogRepository.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Data;
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Implementations
{
    public class SafetyLogRepository : Repository<SafetyLog>, ISafetyLogRepository
    {
        public SafetyLogRepository(SpaceResearchContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SafetyLog>> GetSafetyLogsByMissionAsync(int missionId)
        {
            return await _dbSet
                .Include(sl => sl.Mission)
                .Where(sl => sl.MissionId == missionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SafetyLog>> GetSafetyLogsBySeverityAsync(SeverityLevel severity)
        {
            return await _dbSet
                .Include(sl => sl.Mission)
                .Where(sl => sl.Severity == severity)
                .ToListAsync();
        }
    }
}
