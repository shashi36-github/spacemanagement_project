// Controllers/CostManagementsController.cs
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
    public class CostManagementsController : ControllerBase
    {
        private readonly ICostManagementService _costManagementService;

        public CostManagementsController(ICostManagementService costManagementService)
        {
            _costManagementService = costManagementService;
        }

        /// <summary>
        /// Retrieves all cost records.
        /// </summary>
        /// <returns>List of cost records.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CostManagement>>> GetAllCostManagements()
        {
            var records = await _costManagementService.GetAllCostManagementsAsync();
            return Ok(records);
        }

        /// <summary>
        /// Retrieves a cost record by ID.
        /// </summary>
        /// <param name="id">CostManagement ID.</param>
        /// <returns>CostManagement details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CostManagement>> GetCostManagementById(int id)
        {
            var record = await _costManagementService.GetCostManagementByIdAsync(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        /// <summary>
        /// Creates a new cost record.
        /// </summary>
        /// <param name="costManagement">CostManagement details.</param>
        /// <returns>Created CostManagement.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,FinanceOfficer")]
        public async Task<IActionResult> CreateCostManagement(CostManagement costManagement)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdRecord = await _costManagementService.CreateCostManagementAsync(costManagement);
            return CreatedAtAction(nameof(GetCostManagementById), new { id = createdRecord.CostManagementId }, createdRecord);
        }

        /// <summary>
        /// Updates an existing cost record.
        /// </summary>
        /// <param name="id">CostManagement ID.</param>
        /// <param name="costManagement">Updated CostManagement details.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,FinanceOfficer")]
        public async Task<IActionResult> UpdateCostManagement(int id, CostManagement costManagement)
        {
            if (id != costManagement.CostManagementId)
                return BadRequest(new { message = "CostManagement ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _costManagementService.UpdateCostManagementAsync(costManagement);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a cost record.
        /// </summary>
        /// <param name="id">CostManagement ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,FinanceOfficer")]
        public async Task<IActionResult> DeleteCostManagement(int id)
        {
            var result = await _costManagementService.DeleteCostManagementAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Retrieves cost records by mission ID.
        /// </summary>
        /// <param name="missionId">Mission ID.</param>
        /// <returns>List of cost records for the specified mission.</returns>
        [HttpGet("mission/{missionId}")]
        public async Task<ActionResult<IEnumerable<CostManagement>>> GetCostManagementsByMission(int missionId)
        {
            var records = await _costManagementService.GetCostRecordsByMissionAsync(missionId);
            return Ok(records);
        }

        /// <summary>
        /// Retrieves cost records by expense type.
        /// </summary>
        /// <param name="expenseType">Expense type.</param>
        /// <returns>List of cost records with the specified expense type.</returns>
        [HttpGet("expense/{expenseType}")]
        public async Task<ActionResult<IEnumerable<CostManagement>>> GetCostManagementsByExpenseType(ExpenseType expenseType)
        {
            var records = await _costManagementService.GetCostRecordsByExpenseTypeAsync(expenseType);
            return Ok(records);
        }
    }
}
