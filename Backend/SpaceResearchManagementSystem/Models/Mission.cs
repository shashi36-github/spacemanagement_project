// Models/Mission.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public enum MissionStatus
    {
        Planned,
        InProgress,
        Completed,
        OnHold,
        Cancelled
    }

    public class Mission
    {
        [Key]
        public int MissionId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Objective { get; set; }

        [Required]
        public DateTime LaunchDate { get; set; }

        [Required]
        public MissionStatus Status { get; set; }

        public string AssignedTeam { get; set; }

        [Required]
        public int DirectorId { get; set; }

        // Navigation Properties
        public User Director { get; set; }
        public ICollection<Equipment> Equipments { get; set; }
        public ICollection<ScientificData> ScientificDatas { get; set; }
        public ICollection<ProjectPlan> ProjectPlans { get; set; }
        public ICollection<SafetyLog> SafetyLogs { get; set; }
        public ICollection<MissionPerformance> MissionPerformances { get; set; }
        public ICollection<CostManagement> CostManagements { get; set; }
        public ICollection<EnvironmentalData> EnvironmentalDatas { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
