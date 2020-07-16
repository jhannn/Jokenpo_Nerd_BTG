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
        public void DeleteAllMoves();
        public void DeleteMoveByPlayerName(string playerName);
    }
}
