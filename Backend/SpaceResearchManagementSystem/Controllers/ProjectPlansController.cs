// Controllers/ProjectPlansController.cs
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
    public class ProjectPlansController : ControllerBase
    {
        private readonly IProjectPlanService _projectPlanService;

        public ProjectPlansController(IProjectPlanService projectPlanService)
        {
            _projectPlanService = projectPlanService;
        }

        /// <summary>
        /// Retrieves all project plans.
        /// </summary>
        /// <returns>List of project plans.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectPlan>>> GetAllProjectPlans()
        {
            var plans = await _projectPlanService.GetAllProjectPlansAsync();
            return Ok(plans);
        }

        /// <summary>
        /// Retrieves a project plan by ID.
        /// </summary>
        /// <param name="id">ProjectPlan ID.</param>
        /// <returns>ProjectPlan details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectPlan>> GetProjectPlanById(int id)
        {
            var plan = await _projectPlanService.GetProjectPlanByIdAsync(id);
            if (plan == null)
                return NotFound();

            return Ok(plan);
        }

        /// <summary>
        /// Creates a new project plan.
        /// </summary>
        /// <param name="projectPlan">ProjectPlan details.</param>
        /// <returns>Created ProjectPlan.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Engineer")]
        public async Task<IActionResult> CreateProjectPlan(ProjectPlan projectPlan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPlan = await _projectPlanService.CreateProjectPlanAsync(projectPlan);
            return CreatedAtAction(nameof(GetProjectPlanById), new { id = createdPlan.ProjectPlanId }, createdPlan);
        }

        /// <summary>
        /// Updates an existing project plan.
        /// </summary>
        /// <param name="id">ProjectPlan ID.</param>
        /// <param name="projectPlan">Updated ProjectPlan details.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Engineer")]
        public async Task<IActionResult> UpdateProjectPlan(int id, ProjectPlan projectPlan)
        {
            if (id != projectPlan.ProjectPlanId)
                return BadRequest(new { message = "ProjectPlan ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _projectPlanService.UpdateProjectPlanAsync(projectPlan);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a project plan.
        /// </summary>
        /// <param name="id">ProjectPlan ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Engineer")]
        public async Task<IActionResult> DeleteProjectPlan(int id)
        {
            var result = await _projectPlanService.DeleteProjectPlanAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Retrieves project plans by mission ID.
        /// </summary>
        /// <param name="missionId">Mission ID.</param>
        /// <returns>List of project plans for the specified mission.</returns>
        [HttpGet("mission/{missionId}")]
        public async Task<ActionResult<IEnumerable<ProjectPlan>>> GetProjectPlansByMission(int missionId)
        {
            var plans = await _projectPlanService.GetProjectPlansByMissionAsync(missionId);
            return Ok(plans);
        }

        /// <summary>
        /// Retrieves project plans by engineer ID.
        /// </summary>
        /// <param name="engineerId">Engineer ID.</param>
        /// <returns>List of project plans assigned to the specified engineer.</returns>
        [HttpGet("engineer/{engineerId}")]
        public async Task<ActionResult<IEnumerable<ProjectPlan>>> GetProjectPlansByEngineer(int engineerId)
        {
            var plans = await _projectPlanService.GetProjectPlansByEngineerAsync(engineerId);
            return Ok(plans);
        }
    }
}
