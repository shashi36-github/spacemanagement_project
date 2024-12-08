// Services/Interfaces/IEnvironmentalDataService.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Services.Interfaces
{
    public interface IEnvironmentalDataService
    {
        Task<IEnumerable<EnvironmentalData>> GetAllEnvironmentalDatasAsync();
        Task<EnvironmentalData> GetEnvironmentalDataByIdAsync(int environmentalDataId);
        Task<EnvironmentalData> CreateEnvironmentalDataAsync(EnvironmentalData environmentalData);
        Task<bool> UpdateEnvironmentalDataAsync(EnvironmentalData environmentalData);
        Task<bool> DeleteEnvironmentalDataAsync(int environmentalDataId);
        Task<IEnumerable<EnvironmentalData>> GetEnvironmentalAssessmentsByMissionAsync(int missionId);
        Task<IEnumerable<EnvironmentalData>> GetEnvironmentalAssessmentsByImpactTypeAsync(ImpactType impactType);
    }
}
