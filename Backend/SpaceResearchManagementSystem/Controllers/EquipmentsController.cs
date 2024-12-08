// Controllers/EquipmentsController.cs
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
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentsController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        /// <summary>
        /// Retrieves all equipments.
        /// </summary>
        /// <returns>List of equipments.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetAllEquipments()
        {
            var equipments = await _equipmentService.GetAllEquipmentsAsync();
            return Ok(equipments);
        }

        /// <summary>
        /// Retrieves an equipment by ID.
        /// </summary>
        /// <param name="id">Equipment ID.</param>
        /// <returns>Equipment details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipmentById(int id)
        {
            var equipment = await _equipmentService.GetEquipmentByIdAsync(id);
            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }

        /// <summary>
        /// Creates a new equipment.
        /// </summary>
        /// <param name="equipment">Equipment details.</param>
        /// <returns>Created equipment.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Engineer")]
        public async Task<IActionResult> CreateEquipment(Equipment equipment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdEquipment = await _equipmentService.CreateEquipmentAsync(equipment);
            return CreatedAtAction(nameof(GetEquipmentById), new { id = createdEquipment.EquipmentId }, createdEquipment);
        }

        /// <summary>
        /// Updates an existing equipment.
        /// </summary>
        /// <param name="id">Equipment ID.</param>
        /// <param name="equipment">Updated equipment details.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Engineer")]
        public async Task<IActionResult> UpdateEquipment(int id, Equipment equipment)
        {
            if (id != equipment.EquipmentId)
                return BadRequest(new { message = "Equipment ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _equipmentService.UpdateEquipmentAsync(equipment);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes an equipment.
        /// </summary>
        /// <param name="id">Equipment ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Engineer")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            var result = await _equipmentService.DeleteEquipmentAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Retrieves equipments by mission ID.
        /// </summary>
        /// <param name="missionId">Mission ID.</param>
        /// <returns>List of equipments assigned to the specified mission.</returns>
        [HttpGet("mission/{missionId}")]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipmentsByMission(int missionId)
        {
            var equipments = await _equipmentService.GetEquipmentsByMissionAsync(missionId);
            return Ok(equipments);
        }
    }
}
