using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBTG.Models;
using DesafioBTG.Services;
using DesafioBTG.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioBTG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPlayersService _service;

        public PlayerController(ILogger<PlayerController> logger, IPlayersService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("players")]
        public ActionResult<List<Player>> GetPlayers()
        {
            _logger.LogInformation("Listed all players.");
            return _service.GetPlayers();
        }

        // POST api/<PlayerController>
        [HttpPost("players")]
        public ActionResult<Player> AddPlayer(string name)
        {
            _logger.LogInformation("Created player: {name}", name);
            var player = new Player(name);
            _service.AddPlayer(player);
            return player;
        }

        [HttpDelete("players/{name}")]
        public ActionResult<string> DeletePlayer(string name)
        {
            _logger.LogInformation("Deleted player: {name}", name);
            _service.DeletePlayer(name);
            return name;
        }
    }
}
