// Repositories/Interfaces/ISafetyLogRepository.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Interfaces
{
    public interface ISafetyLogRepository : IRepository<SafetyLog>
    {
        Task<IEnumerable<SafetyLog>> GetSafetyLogsByMissionAsync(int missionId);
        Task<IEnumerable<SafetyLog>> GetSafetyLogsBySeverityAsync(SeverityLevel severity);
    }
}
