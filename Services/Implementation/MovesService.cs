using DesafioBTG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services.Implementation
{
    public class MovesService: IMovesService
    {
        private readonly IPlayersService _playersService;
        private readonly IMovementsTypeService _movementsTypeService;
        private readonly List<Move> _moves;

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
                if (players[index].Name == playerName.ToUpper())
                {
                    indexPlayer = index;
                }
            }
            for (var index = movements.Count - 1; index >= 0; index--)
            {
                if (movements[index].Name == name.ToUpper())
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
        public void DeleteAllMoves()
        {
            _moves.Clear();
        }
    }
}
