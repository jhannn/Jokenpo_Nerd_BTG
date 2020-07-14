using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBTG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioBTG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokenpoController : ControllerBase
    {
        public static int PlayMovement(int movement1, int movement2)
        {
            var rules = new int[,] { { 3, 4 }, { 1, 5 }, { 2, 4 }, { 5, 2 }, { 3, 1 } };

            if (movement1 == movement2)
                return 0;

            for (int i = 0; i < rules.GetLength(1); i++)
                if (rules[movement1 - 1, i] == movement2)
                    return movement1;

            return movement2;
        }
        
        private readonly ILogger _logger;

        public JokenpoController(ILogger<JokenpoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult PlayGame()
        {
            var resultado = PlayMovement(1, 4);
            _logger.LogInformation("Teste de um exemplo de jokenpo:{resultado}", resultado);
            return Ok();
        }
    }
}
