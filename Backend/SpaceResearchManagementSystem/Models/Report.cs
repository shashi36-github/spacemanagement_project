// Models/Report.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public enum ReportType
    {
        Technical,
        Financial,
        Progress,
        Safety,
        Environmental
    }

    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        public ReportType Type { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime GeneratedDate { get; set; }

        [Required]
        public int CreatedById { get; set; }

        // Navigation Properties
        public User CreatedBy { get; set; }
    }
}
