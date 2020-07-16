﻿using DesafioBTG.Models;
using DesafioBTG.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Services.Implementation
{
    public class PlayersService : IPlayersService
    {
        private readonly List<Player> _players;

        public PlayersService()
        {
            _players = new List<Player>();
        }
        public List<Player> GetPlayers()
        {
            return _players;
        }
        public Player AddPlayer(string name)
        {
            if (name != null)
            {
                foreach (var element in _players)
                {
                    if (element.Name == name.ToUpper())
                    {
                        return null;
                    }
                }
                var player = new Player(name.ToUpper());
                _players.Add(player);
                return player;
            }
            return null;
        }
        public void DeleteAllPlayers()
        {
            _players.Clear();
        }
    }
}
