using System;
using System.Collections.Generic;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Player
{
    public class PlayerManager : IGameObjectManager
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly ICollisionSystem _collisionSystem;
        private List<Player> _players;
        private bool _isPaused;

        public PlayerManager(IPlayerFactory playerFactory, ICollisionSystem collisionSystem)
        {
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
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
                _collisionSystem.RegisterEntity(player);
            }
        }

        public void Update(IGameTime gameTime)
        {
            if (_isPaused) return;

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

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }
    }
}