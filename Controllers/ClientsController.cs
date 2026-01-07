using Microsoft.AspNetCore.Mvc;
using StoreService.Services;

namespace StoreService.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("birthdays")]
        public async Task<IActionResult> GetBirthdays([FromQuery] DateTime? date)
        {
            if (!date.HasValue)
                return BadRequest(new { message = "Parameter 'date' is required." });

            var result = await _service.GetBirthdays(date.Value);
            return Ok(result);
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecent([FromQuery] int days)
        {
            if (days <= 0)
                return BadRequest(new { message = "'days' must be greater than 0." });

            var result = await _service.GetRecentClients(days);
            return Ok(result);
        }

        [HttpGet("{clientId}/categories")]
        public async Task<IActionResult> GetCategories(int clientId)
        {
            if (clientId <= 0)
                return BadRequest(new { message = "'clientId' must be greater than 0." });

            var result = await _service.GetClientCategories(clientId);
            if (!result.Any())
                return NotFound(new { message = "Client not found or no purchases." });

            return Ok(result);
        }
    }
}