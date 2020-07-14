using DesafioBTG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services
{
    public interface IPlayersService
    {
        public List<Player> GetPlayers();
        public Player AddPlayer(Player player);
        public string DeletePlayer(string name);
        public void DeleteAllPlayers();
    }
}
