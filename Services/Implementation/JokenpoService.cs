using DesafioBTG.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services.Implementation
{
    public class JokenpoService : IJokenpoService
    {
        private readonly IPlayersService _playersService;
        private readonly IMovesService _movesService;

        public JokenpoService(IPlayersService playersService, IMovesService movesService)
        {
            _playersService = playersService;
            _movesService = movesService;
        }
        public string Play(string namePlayer1, string namePlayer2)
        {
            var result = "Invalid game";
            var moves = _movesService.GetMoves();
            Move movePlayer1 = null;
            Move movePlayer2 = null;
            if (moves.Count >= 2 && namePlayer1 != namePlayer2 && namePlayer1 != null && namePlayer2 != null)
            {
                foreach (var move in moves)
                {
                    if (move.Player.Name == namePlayer1.ToUpper())
                    {
                        movePlayer1 = move;
                    }
                    else if (move.Player.Name == namePlayer2.ToUpper())
                    {
                        movePlayer2 = move;
                    }
                }
                if (movePlayer1 != null && movePlayer2 != null)
                {
                    result = "Player: " + movePlayer1.Player.Name + " won";
                    if (movePlayer1.Movement.Name == movePlayer2.Movement.Name)
                    {
                        result = "Draw";
                    }
                    else
                    {
                        foreach (var element in movePlayer1.Movement.Weakness)
                        {
                            if (element == movePlayer2.Movement.Name)
                            {
                                result = "Player: " + movePlayer2.Player.Name + " won";
                            }
                        }
                    }
                    _movesService.DeleteMoveByPlayerName(namePlayer1.ToUpper());
                    _movesService.DeleteMoveByPlayerName(namePlayer2.ToUpper());
                }
            }
            return result;
        }
        public string Reset()
        {
            _movesService.DeleteAllMoves();
            _playersService.DeleteAllPlayers();
            return "New game, please put new players and moves.";
        }
    }
}
