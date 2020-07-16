using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBTG.Models;
using DesafioBTG.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioBTG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokenpoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJokenpoService _service;

        public JokenpoController(ILogger<JokenpoController> logger, IJokenpoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("jokenpo")]
        public ActionResult<string> Play(string namePlayer1, string namePlayer2)
        {
            try
            {
                _logger.LogInformation("Game started");
                return _service.Play(namePlayer1, namePlayer2);
            }
            catch (Exception)
            {
                _logger.LogError("Error playing jokenpo");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("jokenpo")]
        public ActionResult<string> Reset()
        {
            try
            {
                _logger.LogInformation("Game reseted");
                return _service.Reset();
            }
            catch (Exception)
            {
                _logger.LogError("Error reseting jokenpo");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
