// Services/Interfaces/ISafetyLogService.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Services.Interfaces
{
    public interface ISafetyLogService
    {
        Task<IEnumerable<SafetyLog>> GetAllSafetyLogsAsync();
        Task<SafetyLog> GetSafetyLogByIdAsync(int safetyLogId);
        Task<SafetyLog> CreateSafetyLogAsync(SafetyLog safetyLog);
        Task<bool> UpdateSafetyLogAsync(SafetyLog safetyLog);
        Task<bool> DeleteSafetyLogAsync(int safetyLogId);
        Task<IEnumerable<SafetyLog>> GetSafetyLogsByMissionAsync(int missionId);
        Task<IEnumerable<SafetyLog>> GetSafetyLogsBySeverityAsync(SeverityLevel severity);
    }
}
