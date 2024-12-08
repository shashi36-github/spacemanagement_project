// Models/Notification.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceResearchManagementSystem.Models
{
    public enum NotificationType
    {
        Info,
        Warning,
        Alert,
        Critical
    }

    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        public NotificationType Type { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public int UserId { get; set; }

        // Navigation Properties
        public User User { get; set; }
    }
}
