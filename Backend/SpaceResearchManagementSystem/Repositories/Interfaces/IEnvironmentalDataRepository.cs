// Repositories/Interfaces/IEnvironmentalDataRepository.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Interfaces
{
    public interface IEnvironmentalDataRepository : IRepository<EnvironmentalData>
    {
        Task<IEnumerable<EnvironmentalData>> GetEnvironmentalAssessmentsByMissionAsync(int missionId);
        Task<IEnumerable<EnvironmentalData>> GetEnvironmentalAssessmentsByImpactTypeAsync(ImpactType impactType);
    }
}
