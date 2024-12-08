// Repositories/Implementations/EquipmentRepository.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Data;
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Implementations
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(SpaceResearchContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Equipment>> GetEquipmentsByMissionAsync(int missionId)
        {
            return await _dbSet
                .Where(e => e.AssignedMissionId == missionId)
                .ToListAsync();
        }
    }
}
