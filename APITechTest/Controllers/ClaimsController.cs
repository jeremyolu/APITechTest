using APITechTest.Models;
using APITechTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace APITechTest.Controllers
{
    [ApiController]
    [Route("claims")]
    public class ClaimsController : ControllerBase
    {
        private readonly ILogger<ClaimsController> _logger;

        private readonly IClaimService _claimsService;

        public ClaimsController(ILogger<ClaimsController> logger, IClaimService claimsService)
        {
            _logger = logger;
            _claimsService = claimsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var claims = _claimsService.GetClaims();

            return Ok(new { total = claims.Count, claims = claims});
        }

        [HttpGet("getclaim")]
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest(new { response = "Identifier not supplied in request" });
            }

            var claim = _claimsService.GetClaimById(id.Value);

            if (claim == null)
            {
                return NotFound();
            }

            return Ok(claim);
        }

        [HttpGet("getcompanyclaims")]
        public IActionResult GetCompanyClaims(int? id)
        {
            if (id == null)
            {
                return BadRequest(new { response = "Identifier not supplied in request" });
            }

            var companyClaims = _claimsService.GetCompanyClaims(id.Value);

            return Ok(companyClaims);
        }

        [HttpPatch("updateclaim")]
        public IActionResult GetCompanyClaims(int? id, Claim data)
        {
            if (id == null)
            {
                return BadRequest(new { response = "Identifier not supplied in request" });
            }

            var result = _claimsService.UpdateClaim(id.Value, data);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
