using APITechTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace APITechTest.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ILogger<CompaniesController> _logger;

        private readonly ICompanyService _companyService;

        public CompaniesController(ILogger<CompaniesController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var companies = _companyService.GetCompanies();

            return Ok(new { total = companies.Count, companies = companies });
        }

        [HttpGet("getcompany")]
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest(new { response = "Identifier not supplied in request" });
            }

            var company = _companyService.GetCompanyById(id);

            if (company == null)
            {
                return NotFound(new { status = "Identifier not supplied in request" });
            }

            return Ok(company);
        }
    }
}