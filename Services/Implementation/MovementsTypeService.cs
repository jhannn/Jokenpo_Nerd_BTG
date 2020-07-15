using DesafioBTG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services.Implementation
{
    public class MovementsTypeService : IMovementsTypeService
    {
        private readonly List<MovementType> _movements;

        public MovementsTypeService()
        {
            _movements = new List<MovementType>
            {
                new MovementType("SPOCK", new List<String> { "LIZARD", "PAPER" }),
                new MovementType("SCISSORS", new List<String> { "SPOCK", "STONE" }),
                new MovementType("PAPER", new List<String> { "SCISSORS", "LIZARD" }),
                new MovementType("STONE", new List<String> { "SPOCK", "PAPER" }),
                new MovementType("LIZARD", new List<String> { "SCISSORS", "STONE" })
            };
        }
        public List<MovementType> GetAll()
        {
            return _movements;
        }
    }
}
