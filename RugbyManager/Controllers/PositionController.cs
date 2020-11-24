using Microsoft.AspNetCore.Mvc;
using RugbyManager.Contracts;
using RugbyManager.Models;

namespace RugbyManager.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public GetPositionsResponse Get()
        {
            return _positionService.Get();
        }
    }
}
