// Controllers/MissionPerformancesController.cs
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
    public class MissionPerformancesController : ControllerBase
    {
        private readonly IMissionPerformanceService _missionPerformanceService;

        public MissionPerformancesController(IMissionPerformanceService missionPerformanceService)
        {
            _missionPerformanceService = missionPerformanceService;
        }

        /// <summary>
        /// Retrieves all mission performances.
        /// </summary>
        /// <returns>List of mission performances.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionPerformance>>> GetAllMissionPerformances()
        {
            var performances = await _missionPerformanceService.GetAllMissionPerformancesAsync();
            return Ok(performances);
        }

        /// <summary>
        /// Retrieves a mission performance by ID.
        /// </summary>
        /// <param name="id">MissionPerformance ID.</param>
        /// <returns>MissionPerformance details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MissionPerformance>> GetMissionPerformanceById(int id)
        {
            var performance = await _missionPerformanceService.GetMissionPerformanceByIdAsync(id);
            if (performance == null)
                return NotFound();

            return Ok(performance);
        }

        /// <summary>
        /// Creates a new mission performance.
        /// </summary>
        /// <param name="missionPerformance">MissionPerformance details.</param>
        /// <returns>Created MissionPerformance.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> CreateMissionPerformance(MissionPerformance missionPerformance)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPerformance = await _missionPerformanceService.CreateMissionPerformanceAsync(missionPerformance);
            return CreatedAtAction(nameof(GetMissionPerformanceById), new { id = createdPerformance.MissionPerformanceId }, createdPerformance);
        }

        /// <summary>
        /// Updates an existing mission performance.
        /// </summary>
        /// <param name="id">MissionPerformance ID.</param>
        /// <param name="missionPerformance">Updated MissionPerformance details.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> UpdateMissionPerformance(int id, MissionPerformance missionPerformance)
        {
            if (id != missionPerformance.MissionPerformanceId)
                return BadRequest(new { message = "MissionPerformance ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _missionPerformanceService.UpdateMissionPerformanceAsync(missionPerformance);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a mission performance.
        /// </summary>
        /// <param name="id">MissionPerformance ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> DeleteMissionPerformance(int id)
        {
            var result = await _missionPerformanceService.DeleteMissionPerformanceAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Retrieves mission performances by mission ID.
        /// </summary>
        /// <param name="missionId">Mission ID.</param>
        /// <returns>List of mission performances for the specified mission.</returns>
        [HttpGet("mission/{missionId}")]
        public async Task<ActionResult<IEnumerable<MissionPerformance>>> GetMissionPerformancesByMission(int missionId)
        {
            var performances = await _missionPerformanceService.GetMissionPerformancesByMissionAsync(missionId);
            return Ok(performances);
        }

        /// <summary>
        /// Retrieves mission performances by supervisor ID.
        /// </summary>
        /// <param name="supervisorId">Supervisor ID.</param>
        /// <returns>List of mission performances overseen by the specified supervisor.</returns>
        [HttpGet("supervisor/{supervisorId}")]
        public async Task<ActionResult<IEnumerable<MissionPerformance>>> GetMissionPerformancesBySupervisor(int supervisorId)
        {
            var performances = await _missionPerformanceService.GetMissionPerformancesBySupervisorAsync(supervisorId);
            return Ok(performances);
        }
    }
}
