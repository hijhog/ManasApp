using ManasApp.Services.Contract.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManasApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocalityController : ControllerBase
    {
        private readonly ILocalityService _localityService;
        public LocalityController(ILocalityService localityService)
        {
            _localityService = localityService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_localityService.GetAll());
        }
    }
}
