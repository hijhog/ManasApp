using ManasApp.Services.Contract.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManasApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/{controller}/{action}")]
    [Authorize]
    public class LocalityController : ControllerBase
    {
        //private readonly ILocalityService _localityService;

        public LocalityController()//ILocalityService localityService)
        {
            //_localityService = localityService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("secret");
        }
    }
}
