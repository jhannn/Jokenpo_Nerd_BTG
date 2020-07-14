using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Models
{
    public class Move
    {
        public Player Player { get; set; }
        public MovementType Movement { get; set; }

        public Move(Player player, MovementType movement)
        {
            this.Player = player;
            this.Movement = movement;
        }
    }
}
