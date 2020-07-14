using DesafioBTG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services
{
    public interface IMovesService
    {
        public List<Move> GetMoves();
        public Move InsertMove(string playerName, string name);
        public string DeleteMoveByPlayerName(string namePlayer);
        public void DeleteAllMoves();
    }
}
