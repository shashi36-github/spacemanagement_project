// Models/User.cs
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public enum UserRole
    {
        Admin,
        MissionDirector,
        Scientist,
        Engineer,
        Astronomer,
        ResearchAssistant,
        SafetyOfficer,
        Supervisor,
        FinanceOfficer,
        Analyst
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Stored as hashed

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<Mission> DirectedMissions { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
