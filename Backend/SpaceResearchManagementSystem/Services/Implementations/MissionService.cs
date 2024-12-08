// Services/Implementations/MissionService.cs
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Services.Implementations
{
    public class MissionService : IMissionService
    {
        private readonly IMissionRepository _missionRepository;

        public MissionService(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public async Task<IEnumerable<Mission>> GetAllMissionsAsync()
        {
            return await _missionRepository.GetAllAsync();
        }

        public async Task<Mission> GetMissionByIdAsync(int missionId)
        {
            return await _missionRepository.GetByIdAsync(missionId);
        }

        public async Task<Mission> CreateMissionAsync(Mission mission)
        {
            return await _missionRepository.AddAsync(mission);
        }

        public async Task<bool> UpdateMissionAsync(Mission mission)
        {
            return await _missionRepository.UpdateAsync(mission);
        }

        public async Task<bool> DeleteMissionAsync(int missionId)
        {
            return await _missionRepository.DeleteAsync(missionId);
        }

        public async Task<IEnumerable<Mission>> GetMissionsByDirectorAsync(int directorId)
        {
            return await _missionRepository.GetMissionsByDirectorAsync(directorId);
        }
    }
}
