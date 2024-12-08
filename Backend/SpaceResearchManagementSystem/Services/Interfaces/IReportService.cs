// Services/Interfaces/IReportService.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<Report> GetReportByIdAsync(int reportId);
        Task<Report> CreateReportAsync(Report report);
        Task<bool> UpdateReportAsync(Report report);
        Task<bool> DeleteReportAsync(int reportId);
        Task<IEnumerable<Report>> GetReportsByTypeAsync(ReportType reportType);
        Task<IEnumerable<Report>> GetReportsByCreatorAsync(int creatorId);
    }
}
