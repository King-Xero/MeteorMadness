using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Bonuses
{
    public class BonusManager : IGameObjectManager
    {
        private readonly IBonusFactory _bonusFactory;
        private readonly ICollisionSystem _collisionSystem;
        private List<IHandleCollisions> _bonuses;
        private Stopwatch _spawnTimer;

        public BonusManager(IBonusFactory bonusFactory, ICollisionSystem collisionSystem)
        {
            _bonusFactory = bonusFactory ?? throw new ArgumentNullException(nameof(bonusFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
        }

        public void Initialize()
        {
            _bonuses = new List<IHandleCollisions>();
            for (int i = 0; i < GameConstants.Bonuses.HealthPack.InitialCount; i++)
            {
                var healthPack = _bonusFactory.CreateHealthPack();
                healthPack.Initialize();
                _collisionSystem.RegisterEntity(healthPack);
                _bonuses.Add(healthPack);
            }

            _spawnTimer = new Stopwatch();
            _spawnTimer.Start();
        }

        public void Update(IGameTime gameTime)
        {
            if (_spawnTimer.Elapsed.Seconds == 30)
            {
                SpawnBonus();
                _spawnTimer.Restart();
            }

            foreach (var bonus in _bonuses)
            {
                if (bonus.IsActive)
                {
                    bonus.Update(gameTime);
                }
            }
        }

        public void Draw(IGameTime gameTime)
        {
            foreach (var bonus in _bonuses)
            {
                if (bonus.IsActive)
                {
                    bonus.Draw(gameTime);
                }
            }
        }

        private void SpawnBonus()
        {
            var bonusToSpawn = _bonuses.FirstOrDefault(b => !b.IsActive);
            if (bonusToSpawn == null)
            {
                bonusToSpawn = _bonusFactory.CreateHealthPack();
                bonusToSpawn.Initialize();

                _bonuses.Add(bonusToSpawn);
            }

            bonusToSpawn.IsActive = true;
        }
    }
}