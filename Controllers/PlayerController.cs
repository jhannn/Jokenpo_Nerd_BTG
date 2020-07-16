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
            try
            {
                _logger.LogInformation("Listed all players");
                return _service.GetPlayers(); ;
            }
            catch (Exception)
            {
                _logger.LogError("Error listing all players");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("players")]
        public ActionResult<Player> AddPlayer(string name)
        {
            try
            {
                var newPlayer = _service.AddPlayer(name);
                if (newPlayer == null)
                {
                    return BadRequest("Player already exist or invalid");
                }
                _logger.LogInformation("Created player: {name}", name);
                return newPlayer;
            }
            catch (Exception)
            {
                _logger.LogError("Error creating player");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
