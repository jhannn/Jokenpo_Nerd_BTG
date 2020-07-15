using DesafioBTG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services.Implementation
{
    public class MovesService : IMovesService
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
            Player player = null;
            MovementType movement = null;
            foreach (var element in _moves)
            {
                if (element.Player.Name == playerName.ToUpper())
                {
                    return null;
                }
            }
            foreach (var element in players)
            {
                if (element.Name == playerName.ToUpper())
                {
                    player = element;
                }
            }
            foreach (var element in movements)
            {
                if (element.Name == name.ToUpper())
                {
                    movement = element;
                }
            }
            if (player != null && movement != null)
            {
                var move = new Move(player, movement);
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
