// Models/CostManagement.cs
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public enum ExpenseType
    {
        Equipment,
        Personnel,
        Travel,
        Research,
        Miscellaneous
    }

    public class CostManagement
    {
        [Key]
        public int CostManagementId { get; set; }

        [Required]
        public int MissionId { get; set; }

        [Required]
        public ExpenseType ExpenseType { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        // Navigation Properties
        public Mission Mission { get; set; }
    }
}
