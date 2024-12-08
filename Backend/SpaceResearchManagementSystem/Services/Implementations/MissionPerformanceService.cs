// Services/Implementations/MissionPerformanceService.cs
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Services.Implementations
{
    public class MissionPerformanceService : IMissionPerformanceService
    {
        private readonly IMissionPerformanceRepository _missionPerformanceRepository;

        public MissionPerformanceService(IMissionPerformanceRepository missionPerformanceRepository)
        {
            _missionPerformanceRepository = missionPerformanceRepository;
        }

        public async Task<IEnumerable<MissionPerformance>> GetAllMissionPerformancesAsync()
        {
            return await _missionPerformanceRepository.GetAllAsync();
        }

        public async Task<MissionPerformance> GetMissionPerformanceByIdAsync(int missionPerformanceId)
        {
            return await _missionPerformanceRepository.GetByIdAsync(missionPerformanceId);
        }

        public async Task<MissionPerformance> CreateMissionPerformanceAsync(MissionPerformance missionPerformance)
        {
            return await _missionPerformanceRepository.AddAsync(missionPerformance);
        }

        public async Task<bool> UpdateMissionPerformanceAsync(MissionPerformance missionPerformance)
        {
            return await _missionPerformanceRepository.UpdateAsync(missionPerformance);
        }

        public async Task<bool> DeleteMissionPerformanceAsync(int missionPerformanceId)
        {
            return await _missionPerformanceRepository.DeleteAsync(missionPerformanceId);
        }

        public async Task<IEnumerable<MissionPerformance>> GetMissionPerformancesByMissionAsync(int missionId)
        {
            return await _missionPerformanceRepository.GetMissionPerformancesByMissionAsync(missionId);
        }

        public async Task<IEnumerable<MissionPerformance>> GetMissionPerformancesBySupervisorAsync(int supervisorId)
        {
            return await _missionPerformanceRepository.GetMissionPerformancesBySupervisorAsync(supervisorId);
        }
    }
}
