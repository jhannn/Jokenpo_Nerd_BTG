using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBTG.Models;
using DesafioBTG.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioBTG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMovesService _service;

        public MoveController(ILogger<MoveController> logger, IMovesService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("moves")]
        public ActionResult<List<Move>> GetMoves()
        {
            try
            {
                _logger.LogInformation("Listed all moves.");
                return _service.GetMoves();
            }
            catch (Exception)
            {
                _logger.LogError("Error listing all moves");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("moves")]
        public ActionResult<Move> InsertMove(string playerName, string name)
        {
            try
            {
                var newMove = _service.InsertMove(playerName, name);
                if (newMove == null)
                {
                    return BadRequest("Move already exist, player or move don't exist");
                }
                _logger.LogInformation("Created move: {name}, player: {playerName}.", name, playerName);
                return newMove;
            }
            catch (Exception)
            {
                _logger.LogError("Error inserting move");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
