// Repositories/Interfaces/IReportRepository.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Interfaces
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<IEnumerable<Report>> GetReportsByTypeAsync(ReportType reportType);
        Task<IEnumerable<Report>> GetReportsByCreatorAsync(int creatorId);
    }
}
