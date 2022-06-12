using ManasApp.Services.Contract.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManasApp.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class MapController : ControllerBase
    {
        private readonly IMapService _mapService;
        
        public MapController(IMapService mapService)
        {
            _mapService = mapService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _mapService.GetAsync(id));
        }
    }
}
