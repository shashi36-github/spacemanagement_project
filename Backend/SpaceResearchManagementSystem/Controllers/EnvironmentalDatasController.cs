// Controllers/EnvironmentalDatasController.cs
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
    public class EnvironmentalDatasController : ControllerBase
    {
        private readonly IEnvironmentalDataService _environmentalDataService;

        public EnvironmentalDatasController(IEnvironmentalDataService environmentalDataService)
        {
            _environmentalDataService = environmentalDataService;
        }

        /// <summary>
        /// Retrieves all environmental assessments.
        /// </summary>
        /// <returns>List of environmental data.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvironmentalData>>> GetAllEnvironmentalDatas()
        {
            var data = await _environmentalDataService.GetAllEnvironmentalDatasAsync();
            return Ok(data);
        }

        /// <summary>
        /// Retrieves environmental data by ID.
        /// </summary>
        /// <param name="id">EnvironmentalData ID.</param>
        /// <returns>EnvironmentalData details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvironmentalData>> GetEnvironmentalDataById(int id)
        {
            var data = await _environmentalDataService.GetEnvironmentalDataByIdAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Creates a new environmental data record.
        /// </summary>
        /// <param name="environmentalData">EnvironmentalData details.</param>
        /// <returns>Created EnvironmentalData.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Scientist")]
        public async Task<IActionResult> CreateEnvironmentalData(EnvironmentalData environmentalData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdData = await _environmentalDataService.CreateEnvironmentalDataAsync(environmentalData);
            return CreatedAtAction(nameof(GetEnvironmentalDataById), new { id = createdData.EnvironmentalDataId }, createdData);
        }

        /// <summary>
        /// Updates an existing environmental data record.
        /// </summary>
        /// <param name="id">EnvironmentalData ID.</param>
        /// <param name="environmentalData">Updated EnvironmentalData details.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Scientist")]
        public async Task<IActionResult> UpdateEnvironmentalData(int id, EnvironmentalData environmentalData)
        {
            if (id != environmentalData.EnvironmentalDataId)
                return BadRequest(new { message = "EnvironmentalData ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _environmentalDataService.UpdateEnvironmentalDataAsync(environmentalData);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes an environmental data record.
        /// </summary>
        /// <param name="id">EnvironmentalData ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Scientist")]
        public async Task<IActionResult> DeleteEnvironmentalData(int id)
        {
            var result = await _environmentalDataService.DeleteEnvironmentalDataAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Retrieves environmental assessments by mission ID.
        /// </summary>
        /// <param name="missionId">Mission ID.</param>
        /// <returns>List of environmental data for the specified mission.</returns>
        [HttpGet("mission/{missionId}")]
        public async Task<ActionResult<IEnumerable<EnvironmentalData>>> GetEnvironmentalDatasByMission(int missionId)
        {
            var data = await _environmentalDataService.GetEnvironmentalAssessmentsByMissionAsync(missionId);
            return Ok(data);
        }

        /// <summary>
        /// Retrieves environmental assessments by impact type.
        /// </summary>
        /// <param name="impactType">Impact type.</param>
        /// <returns>List of environmental data with the specified impact type.</returns>
        [HttpGet("impact/{impactType}")]
        public async Task<ActionResult<IEnumerable<EnvironmentalData>>> GetEnvironmentalDatasByImpactType(ImpactType impactType)
        {
            var data = await _environmentalDataService.GetEnvironmentalAssessmentsByImpactTypeAsync(impactType);
            return Ok(data);
        }
    }
}
