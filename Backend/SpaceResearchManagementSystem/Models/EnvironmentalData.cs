// Models/EnvironmentalData.cs
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public enum ImpactType
    {
        Low,
        Moderate,
        Significant,
        Severe
    }

    public class EnvironmentalData
    {
        [Key]
        public int EnvironmentalDataId { get; set; }

        [Required]
        public int MissionId { get; set; }

        [Required]
        public ImpactType ImpactType { get; set; }

        [Required]
        public string AssessmentDetails { get; set; }

        public DateTime AssessmentDate { get; set; }

        // Navigation Properties
        public Mission Mission { get; set; }
    }
}
