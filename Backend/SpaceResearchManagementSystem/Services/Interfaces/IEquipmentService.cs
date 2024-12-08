// Services/Interfaces/IEquipmentService.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Services.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<Equipment>> GetAllEquipmentsAsync();
        Task<Equipment> GetEquipmentByIdAsync(int equipmentId);
        Task<Equipment> CreateEquipmentAsync(Equipment equipment);
        Task<bool> UpdateEquipmentAsync(Equipment equipment);
        Task<bool> DeleteEquipmentAsync(int equipmentId);
        Task<IEnumerable<Equipment>> GetEquipmentsByMissionAsync(int missionId);
    }
}
