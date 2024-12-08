// Services/Implementations/ProjectPlanService.cs
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Services.Implementations
{
    public class ProjectPlanService : IProjectPlanService
    {
        private readonly IProjectPlanRepository _projectPlanRepository;

        public ProjectPlanService(IProjectPlanRepository projectPlanRepository)
        {
            _projectPlanRepository = projectPlanRepository;
        }

        public async Task<IEnumerable<ProjectPlan>> GetAllProjectPlansAsync()
        {
            return await _projectPlanRepository.GetAllAsync();
        }

        public async Task<ProjectPlan> GetProjectPlanByIdAsync(int projectPlanId)
        {
            return await _projectPlanRepository.GetByIdAsync(projectPlanId);
        }

        public async Task<ProjectPlan> CreateProjectPlanAsync(ProjectPlan projectPlan)
        {
            return await _projectPlanRepository.AddAsync(projectPlan);
        }

        public async Task<bool> UpdateProjectPlanAsync(ProjectPlan projectPlan)
        {
            return await _projectPlanRepository.UpdateAsync(projectPlan);
        }

        public async Task<bool> DeleteProjectPlanAsync(int projectPlanId)
        {
            return await _projectPlanRepository.DeleteAsync(projectPlanId);
        }

        public async Task<IEnumerable<ProjectPlan>> GetProjectPlansByMissionAsync(int missionId)
        {
            return await _projectPlanRepository.GetProjectPlansByMissionAsync(missionId);
        }

        public async Task<IEnumerable<ProjectPlan>> GetProjectPlansByEngineerAsync(int engineerId)
        {
            return await _projectPlanRepository.GetProjectPlansByEngineerAsync(engineerId);
        }
    }
}
