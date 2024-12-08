// Services/Implementations/ScientificDataService.cs
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Services.Implementations
{
    public class ScientificDataService : IScientificDataService
    {
        private readonly IScientificDataRepository _scientificDataRepository;

        public ScientificDataService(IScientificDataRepository scientificDataRepository)
        {
            _scientificDataRepository = scientificDataRepository;
        }

        public async Task<IEnumerable<ScientificData>> GetAllScientificDatasAsync()
        {
            return await _scientificDataRepository.GetAllAsync();
        }

        public async Task<ScientificData> GetScientificDataByIdAsync(int scientificDataId)
        {
            return await _scientificDataRepository.GetByIdAsync(scientificDataId);
        }

        public async Task<ScientificData> CreateScientificDataAsync(ScientificData scientificData)
        {
            return await _scientificDataRepository.AddAsync(scientificData);
        }

        public async Task<bool> UpdateScientificDataAsync(ScientificData scientificData)
        {
            return await _scientificDataRepository.UpdateAsync(scientificData);
        }

        public async Task<bool> DeleteScientificDataAsync(int scientificDataId)
        {
            return await _scientificDataRepository.DeleteAsync(scientificDataId);
        }

        public async Task<IEnumerable<ScientificData>> GetScientificDataByMissionAsync(int missionId)
        {
            return await _scientificDataRepository.GetScientificDataByMissionAsync(missionId);
        }

        public async Task<IEnumerable<ScientificData>> GetScientificDataByResearcherAsync(int researcherId)
        {
            return await _scientificDataRepository.GetScientificDataByResearcherAsync(researcherId);
        }
    }
}
