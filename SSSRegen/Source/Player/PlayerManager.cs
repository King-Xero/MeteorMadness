using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Player
{
    public class PlayerManager : IGameObjectManager
    {
        private readonly IPlayerFactory _playerFactory;
        private List<Player> _players;

        public PlayerManager(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
        }

        public void Initialize()
        {
            _players = new List<Player>()
            {
                _playerFactory.CreatePlayer()
            };

            foreach (var player in _players)
            {
                player.Initialize();
            }
        }

        public void Update(IGameTime gameTime)
        {
            foreach (var player in _players)
            {
                player.Update(gameTime);
            }
        }

        public void Draw(IGameTime gameTime)
        {
            foreach (var player in _players)
            {
                player.Draw(gameTime);
            }
        }
    }
}