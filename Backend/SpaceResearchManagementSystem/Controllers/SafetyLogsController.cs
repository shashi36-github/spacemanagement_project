// Controllers/SafetyLogsController.cs
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
    public class SafetyLogsController : ControllerBase
    {
        private readonly ISafetyLogService _safetyLogService;

        public SafetyLogsController(ISafetyLogService safetyLogService)
        {
            _safetyLogService = safetyLogService;
        }

        /// <summary>
        /// Retrieves all safety logs.
        /// </summary>
        /// <returns>List of safety logs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SafetyLog>>> GetAllSafetyLogs()
        {
            var logs = await _safetyLogService.GetAllSafetyLogsAsync();
            return Ok(logs);
        }

        /// <summary>
        /// Retrieves a safety log by ID.
        /// </summary>
        /// <param name="id">SafetyLog ID.</param>
        /// <returns>SafetyLog details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SafetyLog>> GetSafetyLogById(int id)
        {
            var log = await _safetyLogService.GetSafetyLogByIdAsync(id);
            if (log == null)
                return NotFound();

            return Ok(log);
        }

        /// <summary>
        /// Creates a new safety log.
        /// </summary>
        /// <param name="safetyLog">SafetyLog details.</param>
        /// <returns>Created SafetyLog.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,SafetyOfficer")]
        public async Task<IActionResult> CreateSafetyLog(SafetyLog safetyLog)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdLog = await _safetyLogService.CreateSafetyLogAsync(safetyLog);
            return CreatedAtAction(nameof(GetSafetyLogById), new { id = createdLog.SafetyLogId }, createdLog);
        }

        /// <summary>
        /// Updates an existing safety log.
        /// </summary>
        /// <param name="id">SafetyLog ID.</param>
        /// <param name="safetyLog">Updated SafetyLog details.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SafetyOfficer")]
        public async Task<IActionResult> UpdateSafetyLog(int id, SafetyLog safetyLog)
        {
            if (id != safetyLog.SafetyLogId)
                return BadRequest(new { message = "SafetyLog ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _safetyLogService.UpdateSafetyLogAsync(safetyLog);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a safety log.
        /// </summary>
        /// <param name="id">SafetyLog ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SafetyOfficer")]
        public async Task<IActionResult> DeleteSafetyLog(int id)
        {
            var result = await _safetyLogService.DeleteSafetyLogAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Retrieves safety logs by mission ID.
        /// </summary>
        /// <param name="missionId">Mission ID.</param>
        /// <returns>List of safety logs for the specified mission.</returns>
        [HttpGet("mission/{missionId}")]
        public async Task<ActionResult<IEnumerable<SafetyLog>>> GetSafetyLogsByMission(int missionId)
        {
            var logs = await _safetyLogService.GetSafetyLogsByMissionAsync(missionId);
            return Ok(logs);
        }

        /// <summary>
        /// Retrieves safety logs by severity level.
        /// </summary>
        /// <param name="severity">Severity level.</param>
        /// <returns>List of safety logs with the specified severity.</returns>
        [HttpGet("severity/{severity}")]
        public async Task<ActionResult<IEnumerable<SafetyLog>>> GetSafetyLogsBySeverity(SeverityLevel severity)
        {
            var logs = await _safetyLogService.GetSafetyLogsBySeverityAsync(severity);
            return Ok(logs);
        }
    }
}
