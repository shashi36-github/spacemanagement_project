// Repositories/Implementations/ProjectPlanRepository.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Data;
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Implementations
{
    public class ProjectPlanRepository : Repository<ProjectPlan>, IProjectPlanRepository
    {
        public ProjectPlanRepository(SpaceResearchContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProjectPlan>> GetProjectPlansByMissionAsync(int missionId)
        {
            return await _dbSet
                .Include(pp => pp.Mission)
                .Include(pp => pp.AssignedEngineer)
                .Where(pp => pp.MissionId == missionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectPlan>> GetProjectPlansByEngineerAsync(int engineerId)
        {
            return await _dbSet
                .Include(pp => pp.Mission)
                .Include(pp => pp.AssignedEngineer)
                .Where(pp => pp.AssignedEngineerId == engineerId)
                .ToListAsync();
        }
    }
}
