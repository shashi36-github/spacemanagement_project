// Repositories/Interfaces/IMissionPerformanceRepository.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Interfaces
{
    public interface IMissionPerformanceRepository : IRepository<MissionPerformance>
    {
        Task<IEnumerable<MissionPerformance>> GetMissionPerformancesByMissionAsync(int missionId);
        Task<IEnumerable<MissionPerformance>> GetMissionPerformancesBySupervisorAsync(int supervisorId);
    }
}
