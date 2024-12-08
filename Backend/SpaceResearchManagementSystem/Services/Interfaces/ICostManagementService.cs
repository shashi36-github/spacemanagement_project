// Services/Interfaces/ICostManagementService.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Services.Interfaces
{
    public interface ICostManagementService
    {
        Task<IEnumerable<CostManagement>> GetAllCostManagementsAsync();
        Task<CostManagement> GetCostManagementByIdAsync(int costManagementId);
        Task<CostManagement> CreateCostManagementAsync(CostManagement costManagement);
        Task<bool> UpdateCostManagementAsync(CostManagement costManagement);
        Task<bool> DeleteCostManagementAsync(int costManagementId);
        Task<IEnumerable<CostManagement>> GetCostRecordsByMissionAsync(int missionId);
        Task<IEnumerable<CostManagement>> GetCostRecordsByExpenseTypeAsync(ExpenseType expenseType);
    }
}
