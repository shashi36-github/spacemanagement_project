// Repositories/Interfaces/INotificationRepository.cs
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceResearchManagementSystem.Repositories.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetNotificationsByUserAsync(int userId);
        Task<IEnumerable<Notification>> GetNotificationsByTypeAsync(NotificationType type);
    }
}
