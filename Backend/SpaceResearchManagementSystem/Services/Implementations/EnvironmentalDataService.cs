// Services/Implementations/EnvironmentalDataService.cs
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Services.Implementations
{
    public class EnvironmentalDataService : IEnvironmentalDataService
    {
        private readonly IEnvironmentalDataRepository _environmentalDataRepository;

        public EnvironmentalDataService(IEnvironmentalDataRepository environmentalDataRepository)
        {
            _environmentalDataRepository = environmentalDataRepository;
        }

        public async Task<IEnumerable<EnvironmentalData>> GetAllEnvironmentalDatasAsync()
        {
            return await _environmentalDataRepository.GetAllAsync();
        }

        public async Task<EnvironmentalData> GetEnvironmentalDataByIdAsync(int environmentalDataId)
        {
            return await _environmentalDataRepository.GetByIdAsync(environmentalDataId);
        }

        public async Task<EnvironmentalData> CreateEnvironmentalDataAsync(EnvironmentalData environmentalData)
        {
            return await _environmentalDataRepository.AddAsync(environmentalData);
        }

        public async Task<bool> UpdateEnvironmentalDataAsync(EnvironmentalData environmentalData)
        {
            return await _environmentalDataRepository.UpdateAsync(environmentalData);
        }

        public async Task<bool> DeleteEnvironmentalDataAsync(int environmentalDataId)
        {
            return await _environmentalDataRepository.DeleteAsync(environmentalDataId);
        }

        public async Task<IEnumerable<EnvironmentalData>> GetEnvironmentalAssessmentsByMissionAsync(int missionId)
        {
            return await _environmentalDataRepository.GetEnvironmentalAssessmentsByMissionAsync(missionId);
        }

        public async Task<IEnumerable<EnvironmentalData>> GetEnvironmentalAssessmentsByImpactTypeAsync(ImpactType impactType)
        {
            return await _environmentalDataRepository.GetEnvironmentalAssessmentsByImpactTypeAsync(impactType);
        }
    }
}
