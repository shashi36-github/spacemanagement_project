// Services/Implementations/SafetyLogService.cs
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Services.Implementations
{
    public class SafetyLogService : ISafetyLogService
    {
        private readonly ISafetyLogRepository _safetyLogRepository;

        public SafetyLogService(ISafetyLogRepository safetyLogRepository)
        {
            _safetyLogRepository = safetyLogRepository;
        }

        public async Task<IEnumerable<SafetyLog>> GetAllSafetyLogsAsync()
        {
            return await _safetyLogRepository.GetAllAsync();
        }

        public async Task<SafetyLog> GetSafetyLogByIdAsync(int safetyLogId)
        {
            return await _safetyLogRepository.GetByIdAsync(safetyLogId);
        }

        public async Task<SafetyLog> CreateSafetyLogAsync(SafetyLog safetyLog)
        {
            return await _safetyLogRepository.AddAsync(safetyLog);
        }

        public async Task<bool> UpdateSafetyLogAsync(SafetyLog safetyLog)
        {
            return await _safetyLogRepository.UpdateAsync(safetyLog);
        }

        public async Task<bool> DeleteSafetyLogAsync(int safetyLogId)
        {
            return await _safetyLogRepository.DeleteAsync(safetyLogId);
        }

        public async Task<IEnumerable<SafetyLog>> GetSafetyLogsByMissionAsync(int missionId)
        {
            return await _safetyLogRepository.GetSafetyLogsByMissionAsync(missionId);
        }

        public async Task<IEnumerable<SafetyLog>> GetSafetyLogsBySeverityAsync(SeverityLevel severity)
        {
            return await _safetyLogRepository.GetSafetyLogsBySeverityAsync(severity);
        }
    }
}
