// Models/MissionPerformance.cs
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public class MissionPerformance
    {
        [Key]
        public int MissionPerformanceId { get; set; }

        [Required]
        public int MissionId { get; set; }

        [Required]
        public int SupervisorId { get; set; }

        [Required]
        public string PerformanceMetrics { get; set; }

        public string Comments { get; set; }

        // Navigation Properties
        public Mission Mission { get; set; }
        public User Supervisor { get; set; }
    }
}
