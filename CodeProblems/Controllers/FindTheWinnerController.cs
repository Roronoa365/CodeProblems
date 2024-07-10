using CodeProblems.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeProblems.Controllers
{
    [ApiController]
    public class FindTheWinnerController : ControllerBase
    {
        private readonly ILogger<FindTheWinnerController> _logger;
        private readonly IFindTheWinnerService _findTheWinnerService;

        public FindTheWinnerController(ILogger<FindTheWinnerController> logger,
            IFindTheWinnerService findTheWinnerService)
        {
            _logger = logger;
            _findTheWinnerService = findTheWinnerService;
        }

        [HttpGet()]
        [Route("findthewinner/{amountOfFriends}/{elimateOnStep}")]
        public IActionResult GetFindTheWinner(int amountOfFriends, int elimateOnStep)
        {
            if (amountOfFriends < 1)
            {
                return BadRequest("[GetFindTheWinner] Amount of friends is not a valid value. Must be greater than 0");
            }

            if (elimateOnStep < 0)
            {
                return BadRequest("[GetFindTheWinner] Elimate on step is not a valid value. Must be greater than 0");
            }

            return Ok(_findTheWinnerService.FindTheWinner(amountOfFriends, elimateOnStep));
        }
    }
}
