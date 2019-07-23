using System;
using System.Collections.Generic;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Player
{
    public class PlayerManager : IGameObjectManager
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly ICollisionSystem _collisionSystem;
        private bool _isPaused;

        public PlayerManager(IPlayerFactory playerFactory, ICollisionSystem collisionSystem)
        {
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
        }

        public static IPlayer Player { get; private set; }

        public void Initialize()
        {
            Player = _playerFactory.CreatePlayer();
            Player.Initialize();
            _collisionSystem.RegisterEntity(Player);
        }

        public void Update(IGameTime gameTime)
        {
            if (_isPaused) return;

            Player.Update(gameTime);
        }

        public void Draw(IGameTime gameTime)
        {
            Player.Draw(gameTime);
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