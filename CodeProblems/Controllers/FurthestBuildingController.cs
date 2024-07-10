using CodeProblems.Services.FurthestBuilding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeProblems.Controllers
{
    [ApiController]
    public class FurthestBuildingController : ControllerBase
    {
        private readonly ILogger<FurthestBuildingController> _logger;
        private readonly IFurthestBuildingService _furthestBuildingService;

        public FurthestBuildingController(ILogger<FurthestBuildingController> logger,
            IFurthestBuildingService furthestBuildingService)
        {
            _logger = logger;
            _furthestBuildingService = furthestBuildingService;
        }

        [HttpPost()]
        [Route("furthestbuilding")]
        public IActionResult PostFurthestBuildingYouCanReach(FurthestBuildingRequest request)
        {
            return Ok(_furthestBuildingService.FurthestBuilding(request.heights, request.bricks, request.ladders));
        }        
    }

    public class FurthestBuildingRequest()
    {
        public int[] heights { get; set; }
        public int bricks { get; set; }
        public int ladders { get; set; }
    }
}
