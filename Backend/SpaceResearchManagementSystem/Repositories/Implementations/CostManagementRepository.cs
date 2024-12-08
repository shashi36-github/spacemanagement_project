// Repositories/Implementations/CostManagementRepository.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Data;
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Implementations
{
    public class CostManagementRepository : Repository<CostManagement>, ICostManagementRepository
    {
        public CostManagementRepository(SpaceResearchContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CostManagement>> GetCostRecordsByMissionAsync(int missionId)
        {
            return await _dbSet
                .Include(cm => cm.Mission)
                .Where(cm => cm.MissionId == missionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CostManagement>> GetCostRecordsByExpenseTypeAsync(ExpenseType expenseType)
        {
            return await _dbSet
                .Include(cm => cm.Mission)
                .Where(cm => cm.ExpenseType == expenseType)
                .ToListAsync();
        }
    }
}
