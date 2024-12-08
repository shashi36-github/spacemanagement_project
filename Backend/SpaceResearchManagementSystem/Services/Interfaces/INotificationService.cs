// Services/Interfaces/INotificationService.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
        Task<Notification> GetNotificationByIdAsync(int notificationId);
        Task<Notification> CreateNotificationAsync(Notification notification);
        Task<bool> UpdateNotificationAsync(Notification notification);
        Task<bool> DeleteNotificationAsync(int notificationId);
        Task<IEnumerable<Notification>> GetNotificationsByUserAsync(int userId);
        Task<IEnumerable<Notification>> GetNotificationsByTypeAsync(NotificationType type);
    }
}
