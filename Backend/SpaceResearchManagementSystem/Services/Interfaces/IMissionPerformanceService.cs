// Services/Interfaces/IMissionPerformanceService.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Services.Interfaces
{
    public interface IMissionPerformanceService
    {
        Task<IEnumerable<MissionPerformance>> GetAllMissionPerformancesAsync();
        Task<MissionPerformance> GetMissionPerformanceByIdAsync(int missionPerformanceId);
        Task<MissionPerformance> CreateMissionPerformanceAsync(MissionPerformance missionPerformance);
        Task<bool> UpdateMissionPerformanceAsync(MissionPerformance missionPerformance);
        Task<bool> DeleteMissionPerformanceAsync(int missionPerformanceId);
        Task<IEnumerable<MissionPerformance>> GetMissionPerformancesByMissionAsync(int missionId);
        Task<IEnumerable<MissionPerformance>> GetMissionPerformancesBySupervisorAsync(int supervisorId);
    }
}
