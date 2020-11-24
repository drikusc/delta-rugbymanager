using Microsoft.AspNetCore.Mvc;
using RugbyManager.Contracts;
using RugbyManager.Models;

namespace RugbyManager.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StadiumController : ControllerBase
    {
        private IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [HttpGet]
        public GetStadiumsResponse Get()
        {
            return _stadiumService.Get();
        }

        [HttpPost]
        public CreateStadiumResponse Create([FromBody] CreateStadiumRequest request)
        {
            return _stadiumService.Create(request);
        }
    }
}
