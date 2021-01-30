using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shareholders.Api.ViewModel;
using Shareholders.Application;

namespace Shareholders.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService companyService;

        public CompanyController(CompanyService companyService)
        {
            this.companyService = companyService;
        }
        
        [HttpGet("")]
        public ActionResult<IEnumerable<CompanyViewModel>> Get()
        {
            return Ok(companyService.GetAllCompanies().Select(c => new CompanyViewModel(c)));
        }
        
        [HttpGet("{id}")]
        public ActionResult<CompanyViewModel> Get([FromRoute] int id)
        {
            return Ok(new CompanyViewModel(companyService.GetCompanyById(id)));
        }
    }
}