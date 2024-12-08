// Controllers/NotificationsController.cs
using Microsoft.AspNetCore.Mvc;
using SpaceResearchManagementSystem.Models;
using SpaceResearchManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceResearchManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// Retrieves all notifications.
        /// </summary>
        /// <returns>List of notifications.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetAllNotifications()
        {
            var notifications = await _notificationService.GetAllNotificationsAsync();
            return Ok(notifications);
        }

        /// <summary>
        /// Retrieves a notification by ID.
        /// </summary>
        /// <param name="id">Notification ID.</param>
        /// <returns>Notification details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetNotificationById(int id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
                return NotFound();

            return Ok(notification);
        }

        /// <summary>
        /// Creates a new notification.
        /// </summary>
        /// <param name="notification">Notification details.</param>
        /// <returns>Created Notification.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> CreateNotification(Notification notification)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdNotification = await _notificationService.CreateNotificationAsync(notification);
            return CreatedAtAction(nameof(GetNotificationById), new { id = createdNotification.NotificationId }, createdNotification);
        }

        /// <summary>
        /// Updates an existing notification.
        /// </summary>
        /// <param name="id">Notification ID.</param>
        /// <param name="notification">Updated Notification details.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> UpdateNotification(int id, Notification notification)
        {
            if (id != notification.NotificationId)
                return BadRequest(new { message = "Notification ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _notificationService.UpdateNotificationAsync(notification);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a notification.
        /// </summary>
        /// <param name="id">Notification ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var result = await _notificationService.DeleteNotificationAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Retrieves notifications by user ID.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns>List of notifications for the specified user.</returns>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotificationsByUser(int userId)
        {
            var notifications = await _notificationService.GetNotificationsByUserAsync(userId);
            return Ok(notifications);
        }

        /// <summary>
        /// Retrieves notifications by type.
        /// </summary>
        /// <param name="notificationType">Notification type.</param>
        /// <returns>List of notifications with the specified type.</returns>
        [HttpGet("type/{notificationType}")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotificationsByType(NotificationType notificationType)
        {
            var notifications = await _notificationService.GetNotificationsByTypeAsync(notificationType);
            return Ok(notifications);
        }
    }
}
