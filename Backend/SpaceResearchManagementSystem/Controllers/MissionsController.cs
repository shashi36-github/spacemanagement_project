// Controllers/MissionsController.cs
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
    public class MissionsController : ControllerBase
    {
        private readonly IMissionService _missionService;

        public MissionsController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        /// <summary>
        /// Retrieves all missions.
        /// </summary>
        /// <returns>List of missions.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mission>>> GetAllMissions()
        {
            var missions = await _missionService.GetAllMissionsAsync();
            return Ok(missions);
        }

        /// <summary>
        /// Retrieves a mission by ID.
        /// </summary>
        /// <param name="id">Mission ID.</param>
        /// <returns>Mission details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Mission>> GetMissionById(int id)
        {
            var mission = await _missionService.GetMissionByIdAsync(id);
            if (mission == null)
                return NotFound();

            return Ok(mission);
        }

        /// <summary>
        /// Creates a new mission.
        /// </summary>
        /// <param name="mission">Mission details.</param>
        /// <returns>Created mission.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,MissionDirector")]
        public async Task<IActionResult> CreateMission(Mission mission)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdMission = await _missionService.CreateMissionAsync(mission);
            return CreatedAtAction(nameof(GetMissionById), new { id = createdMission.MissionId }, createdMission);
        }

        /// <summary>
        /// Updates an existing mission.
        /// </summary>
        /// <param name="id">Mission ID.</param>
        /// <param name="mission">Updated mission details.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,MissionDirector")]
        public async Task<IActionResult> UpdateMission(int id, Mission mission)
        {
            if (id != mission.MissionId)
                return BadRequest(new { message = "Mission ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _missionService.UpdateMissionAsync(mission);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a mission.
        /// </summary>
        /// <param name="id">Mission ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,MissionDirector")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var result = await _missionService.DeleteMissionAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Retrieves missions by director ID.
        /// </summary>
        /// <param name="directorId">Director ID.</param>
        /// <returns>List of missions directed by the specified director.</returns>
        [HttpGet("director/{directorId}")]
        public async Task<ActionResult<IEnumerable<Mission>>> GetMissionsByDirector(int directorId)
        {
            var missions = await _missionService.GetMissionsByDirectorAsync(directorId);
            return Ok(missions);
        }
    }
}
