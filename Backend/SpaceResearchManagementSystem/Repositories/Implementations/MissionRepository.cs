// Repositories/Implementations/MissionRepository.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Data;
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Implementations
{
    public class MissionRepository : Repository<Mission>, IMissionRepository
    {
        public MissionRepository(SpaceResearchContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Mission>> GetMissionsByDirectorAsync(int directorId)
        {
            return await _dbSet
                .Include(m => m.Director)
                .Include(m => m.Equipments)
                .Include(m => m.ScientificDatas)
                .Include(m => m.ProjectPlans)
                .Include(m => m.SafetyLogs)
                .Include(m => m.MissionPerformances)
                .Include(m => m.CostManagements)
                .Include(m => m.EnvironmentalDatas)
                .Include(m => m.Reports)
                .Where(m => m.DirectorId == directorId)
                .ToListAsync();
        }
    }
}
