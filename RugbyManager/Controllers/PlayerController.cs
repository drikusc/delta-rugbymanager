using Microsoft.AspNetCore.Mvc;
using RugbyManager.Contracts;
using RugbyManager.Models;

namespace RugbyManager.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public GetPlayersResponse Get(string firstName, string lastName, decimal? height, string teamName, string positionCode)
        {
            return _playerService.Get(firstName, lastName, height, teamName, positionCode);
        }

        [HttpPost]
        public CreatePlayerResponse Create([FromBody] CreatePlayerRequest request)
        {
            return _playerService.Create(request);
        }

        [HttpPost]
        [Route("transfer")]
        public TransferPlayerResponse Transfer([FromBody] TransferPlayerRequest request)
        {
            return _playerService.Transfer(request);
        }
    }
}