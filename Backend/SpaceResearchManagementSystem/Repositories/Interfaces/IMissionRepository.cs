// Repositories/Interfaces/IMissionRepository.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Interfaces
{
    public interface IMissionRepository : IRepository<Mission>
    {
        Task<IEnumerable<Mission>> GetMissionsByDirectorAsync(int directorId);
    }
}
