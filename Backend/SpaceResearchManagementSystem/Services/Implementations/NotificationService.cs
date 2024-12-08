// Services/Implementations/NotificationService.cs
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await _notificationRepository.GetAllAsync();
        }

        public async Task<Notification> GetNotificationByIdAsync(int notificationId)
        {
            return await _notificationRepository.GetByIdAsync(notificationId);
        }

        public async Task<Notification> CreateNotificationAsync(Notification notification)
        {
            return await _notificationRepository.AddAsync(notification);
        }

        public async Task<bool> UpdateNotificationAsync(Notification notification)
        {
            return await _notificationRepository.UpdateAsync(notification);
        }

        public async Task<bool> DeleteNotificationAsync(int notificationId)
        {
            return await _notificationRepository.DeleteAsync(notificationId);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserAsync(int userId)
        {
            return await _notificationRepository.GetNotificationsByUserAsync(userId);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByTypeAsync(NotificationType type)
        {
            return await _notificationRepository.GetNotificationsByTypeAsync(type);
        }
    }
}
