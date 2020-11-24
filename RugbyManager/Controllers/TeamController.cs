using Microsoft.AspNetCore.Mvc;
using RugbyManager.Contracts;
using RugbyManager.Models;

namespace RugbyManager.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public GetTeamsResponse Get()
        {
            return _teamService.Get();
        }

        [HttpPost]
        public CreateTeamResponse Create([FromBody] CreateTeamRequest request)
        {
            return _teamService.Create(request);
        }

        [HttpPost]
        [Route("stadium/link")]
        public LinkTeamToStadiumResponse LinkStadium(LinkTeamToStadiumRequest request)
        {
            return _teamService.LinkStadium(request);
        }

        [HttpPost]
        [Route("stadium/unlink")]
        public UnlinkTeamToStadiumResponse UnlinkStadium(UnlinkTeamToStadiumRequest request)
        {
            return _teamService.UnlinkStadium(request);
        }
    }
}
