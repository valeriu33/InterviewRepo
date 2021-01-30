using Microsoft.AspNetCore.Mvc;
using Shareholders.Api.ViewModel;
using Shareholders.Application;

namespace Shareholders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService companyService;

        public CompanyController(CompanyService companyService)
        {
            this.companyService = companyService;
        }
        
        [HttpGet("{id}")]
        public ActionResult<CompanyViewModel> Get([FromRoute] int id)
        {
            return Ok(new CompanyViewModel(companyService.GetCompanyById(id)));
        }
    }
}