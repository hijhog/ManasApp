using ManasApp.Services.Contract.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManasApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/{controller}/{action}")]
    [Authorize]
    public class LocalityController : ControllerBase
    {
        private readonly ILocalityService _localityService;

        public LocalityController(ILocalityService localityService)
        {
            _localityService = localityService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _localityService.GetAsync(id));
        }
        
        [HttpGet]
        public async Task<ActionResult> GetSearch(string searchText,int page)
        {
            return Ok(await _localityService.GetSearchPage(searchText, page));
        }

        [HttpGet]
        public string Secret()
        {
            return "secret string";
        }
    }
}
