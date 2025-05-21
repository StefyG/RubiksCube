using Microsoft.AspNetCore.Mvc;
using RubiksCubeChallenge.API.Interfaces;
using RubiksCubeChallenge.API.Models;
using RubiksCubeChallenge.Enums;

namespace RubiksCubeChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RubiksCubeController : ControllerBase
    {
        private readonly IRubiksCubeService _cubeService;

        public RubiksCubeController(IRubiksCubeService cubeService)
        {
            _cubeService = cubeService;
        }

        [HttpGet("state")]
        public ActionResult<Dictionary<Face, string[][]>> GetState()
        {
            return Ok(_cubeService.GetCubeState());
        }

        [HttpPost("rotate")]
        public IActionResult Rotate([FromBody] RotationRequest request)
        {
            _cubeService.Rotate(request.Face, request.Direction);
            return NoContent();
        }

        [HttpPost("reset")]
        public IActionResult Reset()
        {
            _cubeService.Reset();
            return NoContent();
        }
    }
}
