// Repositories/Implementations/MissionPerformanceRepository.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Data;
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Implementations
{
    public class MissionPerformanceRepository : Repository<MissionPerformance>, IMissionPerformanceRepository
    {
        public MissionPerformanceRepository(SpaceResearchContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MissionPerformance>> GetMissionPerformancesByMissionAsync(int missionId)
        {
            return await _dbSet
                .Include(mp => mp.Mission)
                .Include(mp => mp.Supervisor)
                .Where(mp => mp.MissionId == missionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MissionPerformance>> GetMissionPerformancesBySupervisorAsync(int supervisorId)
        {
            return await _dbSet
                .Include(mp => mp.Mission)
                .Include(mp => mp.Supervisor)
                .Where(mp => mp.SupervisorId == supervisorId)
                .ToListAsync();
        }
    }
}
