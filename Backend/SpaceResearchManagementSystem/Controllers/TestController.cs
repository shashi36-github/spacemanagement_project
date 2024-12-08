// Controllers/TestController.cs
using Microsoft.AspNetCore.Mvc;
using System;

namespace SpaceResearchManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("exception")]
        public IActionResult GetException()
        {
            throw new Exception("Test exception for middleware.");
        }
    }
}
