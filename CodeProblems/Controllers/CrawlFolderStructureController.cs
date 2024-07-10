using CodeProblems.Services;
using CodeProblems.Services.FurthestBuilding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeProblems.Controllers
{
    [ApiController]
    public class CrawlFolderStructureController : ControllerBase
    {
        private readonly ILogger<CrawlFolderStructureController> _logger;
        private readonly ICrawlFolderStructureService _crawlFolderStructure;

        public CrawlFolderStructureController(ILogger<CrawlFolderStructureController> logger,
            ICrawlFolderStructureService crawlFolderStructure)
        {
            _logger = logger;
            _crawlFolderStructure = crawlFolderStructure;
        }


        [HttpPost()]
        [Route("crawlfolderstructure")]
        public IActionResult PostFurthestBuildingYouCanReach(string[] logs)
        {
            return Ok(_crawlFolderStructure.MinOperations(logs));
        }        
    }
}
