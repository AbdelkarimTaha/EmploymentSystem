using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicationService _applicantService;

        public ApplicantController(IApplicationService applicationService)
        {
            _applicantService = applicationService;
        }


        /// <summary>
        /// Search for vacancies based on a query.
        /// </summary>
        /// <param name="query">Search query for the vacancy (e.g., title or description).</param>
        /// <returns>List of matching vacancies.</returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchVacancies([FromQuery] string query)
        {
            var result = await _applicantService.SearchVacanciesAsync(query);
            if (result == null)
                return NotFound("No vacancies found matching the query.");

            return Ok(result);
        }

        /// <summary>
        /// Apply for a vacancy.
        /// </summary>
        /// <param name="applicantId">ID of the applicant.</param>
        /// <param name="vacancyId">ID of the vacancy.</param>
        /// <returns>Result of the application process.</returns>
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForVacancy([FromQuery] string applicantId, [FromQuery] string vacancyId)
        {
            var result = await _applicantService.ApplyForVacancyAsync(applicantId, vacancyId);
            if (result is string errorMessage)
                return BadRequest(errorMessage);

            return Ok(result);
        }
    }
}