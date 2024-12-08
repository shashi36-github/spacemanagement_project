// Services/Interfaces/IScientificDataService.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Services.Interfaces
{
    public interface IScientificDataService
    {
        Task<IEnumerable<ScientificData>> GetAllScientificDatasAsync();
        Task<ScientificData> GetScientificDataByIdAsync(int scientificDataId);
        Task<ScientificData> CreateScientificDataAsync(ScientificData scientificData);
        Task<bool> UpdateScientificDataAsync(ScientificData scientificData);
        Task<bool> DeleteScientificDataAsync(int scientificDataId);
        Task<IEnumerable<ScientificData>> GetScientificDataByMissionAsync(int missionId);
        Task<IEnumerable<ScientificData>> GetScientificDataByResearcherAsync(int researcherId);
    }
}
