// Services/Implementations/ReportService.cs
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _reportRepository.GetAllAsync();
        }

        public async Task<Report> GetReportByIdAsync(int reportId)
        {
            return await _reportRepository.GetByIdAsync(reportId);
        }

        public async Task<Report> CreateReportAsync(Report report)
        {
            return await _reportRepository.AddAsync(report);
        }

        public async Task<bool> UpdateReportAsync(Report report)
        {
            return await _reportRepository.UpdateAsync(report);
        }

        public async Task<bool> DeleteReportAsync(int reportId)
        {
            return await _reportRepository.DeleteAsync(reportId);
        }

        public async Task<IEnumerable<Report>> GetReportsByTypeAsync(ReportType reportType)
        {
            return await _reportRepository.GetReportsByTypeAsync(reportType);
        }

        public async Task<IEnumerable<Report>> GetReportsByCreatorAsync(int creatorId)
        {
            return await _reportRepository.GetReportsByCreatorAsync(creatorId);
        }
    }
}
