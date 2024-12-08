// Services/Interfaces/IProjectPlanService.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Services.Interfaces
{
    public interface IProjectPlanService
    {
        Task<IEnumerable<ProjectPlan>> GetAllProjectPlansAsync();
        Task<ProjectPlan> GetProjectPlanByIdAsync(int projectPlanId);
        Task<ProjectPlan> CreateProjectPlanAsync(ProjectPlan projectPlan);
        Task<bool> UpdateProjectPlanAsync(ProjectPlan projectPlan);
        Task<bool> DeleteProjectPlanAsync(int projectPlanId);
        Task<IEnumerable<ProjectPlan>> GetProjectPlansByMissionAsync(int missionId);
        Task<IEnumerable<ProjectPlan>> GetProjectPlansByEngineerAsync(int engineerId);
    }
}
