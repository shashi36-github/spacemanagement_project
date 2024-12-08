// Models/ScientificData.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public class ScientificData
    {
        [Key]
        public int ScientificDataId { get; set; }

        [Required]
        public int MissionId { get; set; }

        [Required]
        public int ResearcherId { get; set; }

        [Required]
        public string DataContent { get; set; }

        public DateTime CollectedDate { get; set; }

        // Navigation Properties
        public Mission Mission { get; set; }
        public User Researcher { get; set; }
    }
}
