// Models/SafetyLog.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public enum SeverityLevel
    {
        Low,
        Medium,
        High,
        Critical
    }

    public class SafetyLog
    {
        [Key]
        public int SafetyLogId { get; set; }

        [Required]
        public int MissionId { get; set; }

        [Required]
        public string IncidentDescription { get; set; }

        [Required]
        public SeverityLevel Severity { get; set; }

        public DateTime ReportedDate { get; set; }

        // Navigation Properties
        public Mission Mission { get; set; }
    }
}
