// Controllers/ScientificDatasController.cs
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
    public class ScientificDatasController : ControllerBase
    {
        private readonly IScientificDataService _scientificDataService;

        public ScientificDatasController(IScientificDataService scientificDataService)
        {
            _scientificDataService = scientificDataService;
        }

        /// <summary>
        /// Retrieves all scientific data.
        /// </summary>
        /// <returns>List of scientific data.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScientificData>>> GetAllScientificDatas()
        {
            var data = await _scientificDataService.GetAllScientificDatasAsync();
            return Ok(data);
        }

        /// <summary>
        /// Retrieves scientific data by ID.
        /// </summary>
        /// <param name="id">ScientificData ID.</param>
        /// <returns>ScientificData details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ScientificData>> GetScientificDataById(int id)
        {
            var data = await _scientificDataService.GetScientificDataByIdAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Creates new scientific data.
        /// </summary>
        /// <param name="scientificData">ScientificData details.</param>
        /// <returns>Created ScientificData.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Scientist")]
        public async Task<IActionResult> CreateScientificData(ScientificData scientificData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdData = await _scientificDataService.CreateScientificDataAsync(scientificData);
            return CreatedAtAction(nameof(GetScientificDataById), new { id = createdData.ScientificDataId }, createdData);
        }

        /// <summary>
        /// Updates existing scientific data.
        /// </summary>
        /// <param name="id">ScientificData ID.</param>
        /// <param name="scientificData">Updated ScientificData details.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Scientist")]
        public async Task<IActionResult> UpdateScientificData(int id, ScientificData scientificData)
        {
            if (id != scientificData.ScientificDataId)
                return BadRequest(new { message = "ScientificData ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _scientificDataService.UpdateScientificDataAsync(scientificData);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes scientific data.
        /// </summary>
        /// <param name="id">ScientificData ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Scientist")]
        public async Task<IActionResult> DeleteScientificData(int id)
        {
            var result = await _scientificDataService.DeleteScientificDataAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Retrieves scientific data by mission ID.
        /// </summary>
        /// <param name="missionId">Mission ID.</param>
        /// <returns>List of scientific data for the specified mission.</returns>
        [HttpGet("mission/{missionId}")]
        public async Task<ActionResult<IEnumerable<ScientificData>>> GetScientificDataByMission(int missionId)
        {
            var data = await _scientificDataService.GetScientificDataByMissionAsync(missionId);
            return Ok(data);
        }

        /// <summary>
        /// Retrieves scientific data by researcher ID.
        /// </summary>
        /// <param name="researcherId">Researcher ID.</param>
        /// <returns>List of scientific data collected by the specified researcher.</returns>
        [HttpGet("researcher/{researcherId}")]
        public async Task<ActionResult<IEnumerable<ScientificData>>> GetScientificDataByResearcher(int researcherId)
        {
            var data = await _scientificDataService.GetScientificDataByResearcherAsync(researcherId);
            return Ok(data);
        }
    }
}
