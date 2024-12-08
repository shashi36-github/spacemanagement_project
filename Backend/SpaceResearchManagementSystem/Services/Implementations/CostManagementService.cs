// Services/Implementations/CostManagementService.cs
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Services.Implementations
{
    public class CostManagementService : ICostManagementService
    {
        private readonly ICostManagementRepository _costManagementRepository;

        public CostManagementService(ICostManagementRepository costManagementRepository)
        {
            _costManagementRepository = costManagementRepository;
        }

        public async Task<IEnumerable<CostManagement>> GetAllCostManagementsAsync()
        {
            return await _costManagementRepository.GetAllAsync();
        }

        public async Task<CostManagement> GetCostManagementByIdAsync(int costManagementId)
        {
            return await _costManagementRepository.GetByIdAsync(costManagementId);
        }

        public async Task<CostManagement> CreateCostManagementAsync(CostManagement costManagement)
        {
            return await _costManagementRepository.AddAsync(costManagement);
        }

        public async Task<bool> UpdateCostManagementAsync(CostManagement costManagement)
        {
            return await _costManagementRepository.UpdateAsync(costManagement);
        }

        public async Task<bool> DeleteCostManagementAsync(int costManagementId)
        {
            return await _costManagementRepository.DeleteAsync(costManagementId);
        }

        public async Task<IEnumerable<CostManagement>> GetCostRecordsByMissionAsync(int missionId)
        {
            return await _costManagementRepository.GetCostRecordsByMissionAsync(missionId);
        }

        public async Task<IEnumerable<CostManagement>> GetCostRecordsByExpenseTypeAsync(ExpenseType expenseType)
        {
            return await _costManagementRepository.GetCostRecordsByExpenseTypeAsync(expenseType);
        }
    }
}
