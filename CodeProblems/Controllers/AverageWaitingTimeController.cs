using CodeProblems.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeProblems.Controllers
{
    [ApiController]
    public class AverageWaitingTimeController : ControllerBase
    {
        private readonly ILogger<AverageWaitingTimeController> _logger;
        private readonly IAverageWaitingTimeService _averageWaitingTimeService;

        public AverageWaitingTimeController(ILogger<AverageWaitingTimeController> logger,
            IAverageWaitingTimeService averageWaitingTimeService)
        {
            _logger = logger;
            _averageWaitingTimeService = averageWaitingTimeService;
        }

        [HttpPost()]
        [Route("averagewaitingtime")]
        public IActionResult PostAverageWaitingTime(int[][] customers)
        {
            return Ok(_averageWaitingTimeService.GetAverageWaitingTime(customers));
        }
    }
}
