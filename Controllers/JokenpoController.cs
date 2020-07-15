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
        public ActionResult<string> Play()
        {
            _logger.LogInformation("Game started.");
            return _service.Play();
        }

        [HttpDelete("jokenpo")]
        public ActionResult<string> Reset()
        {
            _logger.LogInformation("Game reseted.");
            return _service.Reset();
        }
    }
}
