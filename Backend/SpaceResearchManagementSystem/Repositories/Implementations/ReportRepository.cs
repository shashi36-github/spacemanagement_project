// Repositories/Implementations/ReportRepository.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Data;
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Implementations
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(SpaceResearchContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Report>> GetReportsByTypeAsync(ReportType reportType)
        {
            return await _dbSet
                .Include(r => r.CreatedBy)
                .Where(r => r.Type == reportType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsByCreatorAsync(int creatorId)
        {
            return await _dbSet
                .Include(r => r.CreatedBy)
                .Where(r => r.CreatedById == creatorId)
                .ToListAsync();
        }
    }
}
