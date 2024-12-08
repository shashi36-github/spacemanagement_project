// Models/ProjectPlan.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public class ProjectPlan
    {
        [Key]
        public int ProjectPlanId { get; set; }

        [Required]
        public int MissionId { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ScheduledDate { get; set; }

        public int? AssignedEngineerId { get; set; }

        // Navigation Properties
        public Mission Mission { get; set; }
        public User AssignedEngineer { get; set; }
    }
}
