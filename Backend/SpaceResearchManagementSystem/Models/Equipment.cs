// Models/Equipment.cs
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Specifications { get; set; }

        public int? AssignedMissionId { get; set; }

        // Navigation Properties
        public Mission AssignedMission { get; set; }
    }
}
