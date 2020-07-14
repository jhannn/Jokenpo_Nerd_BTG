using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services.Implementation
{
    public class JokenpoService: IJokenpoService
    {
        private IPlayersService _playersService;
        private IMovesService _movesService;

        public JokenpoService(IPlayersService playersService, IMovesService movesService)
        {
            _playersService = playersService;
            _movesService = movesService;
        }
        public string Play()
        {
            var result = "Nothing.";
            var moves = _movesService.GetMoves();
            if (moves.Count >= 2)
            {
                result = "Player one won.";
                if(moves[0].Movement.Name == moves[1].Movement.Name)
                {
                    result = "Draw";
                }
                else
                {
                    foreach(var element in moves[0].Movement.Weakness)
                    {
                        if(element == moves[1].Movement.Name)
                        {
                            result = "Player two won.";
                        }
                    }
                }
            }
            return result;
        }
        public string Reset()
        {
            _movesService.DeleteAllMoves();
            _playersService.DeleteAllPlayers();
            return "New game.";
        }
    }
}
