// Services/Implementations/EquipmentService.cs
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Services.Implementations
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipmentsAsync()
        {
            return await _equipmentRepository.GetAllAsync();
        }

        public async Task<Equipment> GetEquipmentByIdAsync(int equipmentId)
        {
            return await _equipmentRepository.GetByIdAsync(equipmentId);
        }

        public async Task<Equipment> CreateEquipmentAsync(Equipment equipment)
        {
            return await _equipmentRepository.AddAsync(equipment);
        }

        public async Task<bool> UpdateEquipmentAsync(Equipment equipment)
        {
            return await _equipmentRepository.UpdateAsync(equipment);
        }

        public async Task<bool> DeleteEquipmentAsync(int equipmentId)
        {
            return await _equipmentRepository.DeleteAsync(equipmentId);
        }

        public async Task<IEnumerable<Equipment>> GetEquipmentsByMissionAsync(int missionId)
        {
            return await _equipmentRepository.GetEquipmentsByMissionAsync(missionId);
        }
    }
}
