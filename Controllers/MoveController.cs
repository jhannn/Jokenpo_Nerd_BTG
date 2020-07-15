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
            _logger.LogInformation("Listed all moves.");
            return _service.GetMoves();
        }

        [HttpPost("moves")]
        public ActionResult<Move> InsertMove(string playerName, string name)
        {
            _logger.LogInformation("Created move: {name}, player: {playerName}.", name, playerName);
            return _service.InsertMove(playerName, name);
        }

        [HttpDelete("moves")]
        public void DeleteAllMoves()
        {
            _logger.LogInformation("Deleted all moves.");
            _service.DeleteAllMoves();
        }
    }
}
