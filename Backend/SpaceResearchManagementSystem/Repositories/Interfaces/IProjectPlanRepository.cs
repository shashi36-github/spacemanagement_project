// Repositories/Interfaces/IProjectPlanRepository.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Interfaces
{
    public interface IProjectPlanRepository : IRepository<ProjectPlan>
    {
        Task<IEnumerable<ProjectPlan>> GetProjectPlansByMissionAsync(int missionId);
        Task<IEnumerable<ProjectPlan>> GetProjectPlansByEngineerAsync(int engineerId);
    }
}
