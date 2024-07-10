using CodeProblems.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeProblems.Controllers
{
    [ApiController]
    public class MajorityElementController : ControllerBase
    {
        private readonly ILogger<MajorityElementController> _logger;
        private readonly IMajorityElementService _majorityElementService;

        public MajorityElementController(ILogger<MajorityElementController> logger, 
            IMajorityElementService majorityElementService)
        {
            _logger = logger;
            _majorityElementService = majorityElementService;
        }

        [HttpPost()]
        [Route("majorityelement")]
        public IActionResult PostMajorityElement(int[] nums)
        {
            return Ok(_majorityElementService.GetMajorityElement(nums));
        }
    }
}
