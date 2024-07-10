using CodeProblems.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeProblems.Controllers
{
    [ApiController]
    public class FirstPalindromeController : ControllerBase
    {
        private readonly ILogger<FirstPalindromeController> _logger;
        private readonly IFirstPalindromeService _firstPalindromeService;

        public FirstPalindromeController(ILogger<FirstPalindromeController> logger,
            IFirstPalindromeService firstPalindromeService)
        {
            _logger = logger;
            _firstPalindromeService = firstPalindromeService;
        }

        
        [HttpPost()]
        [Route("firstpalindrome")]
        public IActionResult PostFirstPalindrome(string[] words)
        {
            return Ok(_firstPalindromeService.GetFirstPalindrome(words));
        }
    }
}
