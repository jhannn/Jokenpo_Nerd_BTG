using DesafioBTG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services.Implementation
{
    public class MovesService: IMovesService
    {
        private IPlayersService _playersService;
        private IMovementsTypeService _movementsTypeService;
        private List<Move> _moves;

        public MovesService(IPlayersService playersService, IMovementsTypeService movementsTypeService)
        {
            _moves = new List<Move>();
            _playersService = playersService;
            _movementsTypeService = movementsTypeService;
        }
        public List<Move> GetMoves()
        {
            return _moves;
        }
        public Move InsertMove(string playerName, string name)
        {
            var players = _playersService.GetPlayers();
            var movements = _movementsTypeService.GetAll();
            int indexPlayer = -1;
            int indexMovement = -1;
            for (var index = players.Count - 1; index >= 0; index--)
            {
                if (players[index].Name == playerName)
                {
                    indexPlayer = index;
                }
            }
            for (var index = movements.Count - 1; index >= 0; index--)
            {
                if (movements[index].Name == name)
                {
                    indexMovement = index;
                }
            }
            if (indexPlayer >= 0 && indexMovement >= 0)
            {
                var move = new Move(players[indexPlayer], movements[indexMovement]);
                _moves.Add(move);
                return move;
            }
            return null;
        }
        public string DeleteMoveByPlayerName(string playerName)
        {
            for (var index = _moves.Count - 1; index >= 0; index--)
            {
                if (_moves[index].Player.Name == playerName)
                {
                    _moves.RemoveAt(index);
                }
            }

            return playerName;
        }
        public void DeleteAllMoves()
        {
            _moves.Clear();
        }
    }
}
