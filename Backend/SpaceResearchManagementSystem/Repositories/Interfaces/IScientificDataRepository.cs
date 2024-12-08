// Repositories/Interfaces/IScientificDataRepository.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Interfaces
{
    public interface IScientificDataRepository : IRepository<ScientificData>
    {
        Task<IEnumerable<ScientificData>> GetScientificDataByMissionAsync(int missionId);
        Task<IEnumerable<ScientificData>> GetScientificDataByResearcherAsync(int researcherId);
    }
}
