// Services/Interfaces/IMissionService.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Services.Interfaces
{
    public interface IMissionService
    {
        Task<IEnumerable<Mission>> GetAllMissionsAsync();
        Task<Mission> GetMissionByIdAsync(int missionId);
        Task<Mission> CreateMissionAsync(Mission mission);
        Task<bool> UpdateMissionAsync(Mission mission);
        Task<bool> DeleteMissionAsync(int missionId);
        Task<IEnumerable<Mission>> GetMissionsByDirectorAsync(int directorId);
    }
}
