// Repositories/Interfaces/ICostManagementRepository.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Interfaces
{
    public interface ICostManagementRepository : IRepository<CostManagement>
    {
        Task<IEnumerable<CostManagement>> GetCostRecordsByMissionAsync(int missionId);
        Task<IEnumerable<CostManagement>> GetCostRecordsByExpenseTypeAsync(ExpenseType expenseType);
    }
}
