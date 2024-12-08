// Controllers/ReportsController.cs
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
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Retrieves all reports.
        /// </summary>
        /// <returns>List of reports.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetAllReports()
        {
            var reports = await _reportService.GetAllReportsAsync();
            return Ok(reports);
        }

        /// <summary>
        /// Retrieves a report by ID.
        /// </summary>
        /// <param name="id">Report ID.</param>
        /// <returns>Report details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReportById(int id)
        {
            var report = await _reportService.GetReportByIdAsync(id);
            if (report == null)
                return NotFound();

            return Ok(report);
        }

        /// <summary>
        /// Creates a new report.
        /// </summary>
        /// <param name="report">Report details.</param>
        /// <returns>Created Report.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Analyst")]
        public async Task<IActionResult> CreateReport(Report report)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdReport = await _reportService.CreateReportAsync(report);
            return CreatedAtAction(nameof(GetReportById), new { id = createdReport.ReportId }, createdReport);
        }

        /// <summary>
        /// Updates an existing report.
        /// </summary>
        /// <param name="id">Report ID.</param>
        /// <param name="report">Updated Report details.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Analyst")]
        public async Task<IActionResult> UpdateReport(int id, Report report)
        {
            if (id != report.ReportId)
                return BadRequest(new { message = "Report ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _reportService.UpdateReportAsync(report);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a report.
        /// </summary>
        /// <param name="id">Report ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Analyst")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var result = await _reportService.DeleteReportAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Retrieves reports by type.
        /// </summary>
        /// <param name="reportType">Report type.</param>
        /// <returns>List of reports with the specified type.</returns>
        [HttpGet("type/{reportType}")]
        public async Task<ActionResult<IEnumerable<Report>>> GetReportsByType(ReportType reportType)
        {
            var reports = await _reportService.GetReportsByTypeAsync(reportType);
            return Ok(reports);
        }

        /// <summary>
        /// Retrieves reports by creator ID.
        /// </summary>
        /// <param name="creatorId">Creator (User) ID.</param>
        /// <returns>List of reports created by the specified user.</returns>
        [HttpGet("creator/{creatorId}")]
        public async Task<ActionResult<IEnumerable<Report>>> GetReportsByCreator(int creatorId)
        {
            var reports = await _reportService.GetReportsByCreatorAsync(creatorId);
            return Ok(reports);
        }
    }
}
