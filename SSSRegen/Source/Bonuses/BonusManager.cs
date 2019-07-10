﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Bonuses
{
    public class BonusManager : IGameObjectManager
    {
        private readonly IBonusFactory _bonusFactory;
        private readonly ICollisionSystem _collisionSystem;

        private List<IHandleCollisions> _bonuses;
        private List<Timer> _spawnTimers;

        public BonusManager(IBonusFactory bonusFactory, ICollisionSystem collisionSystem)
        {
            _bonusFactory = bonusFactory ?? throw new ArgumentNullException(nameof(bonusFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
        }

        public void Initialize()
        {
            _bonuses = new List<IHandleCollisions>();

            _spawnTimers = new List<Timer>();

            for (int i = 0; i < GameConstants.Bonuses.HealthPack.InitialCount; i++)
            {
                var healthPack = _bonusFactory.CreateHealthPack();
                healthPack.Initialize();
                _collisionSystem.RegisterEntity(healthPack);
                _bonuses.Add(healthPack);
            }

            AddSpawnTimer(30000, _bonusFactory.CreateHealthPack);

            foreach (var spawnTimer in _spawnTimers)
            {
                spawnTimer.Start();
            }
        }

        public void Update(IGameTime gameTime)
        {
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

        private void AddSpawnTimer(int interval, Func<HealthPack> createBonus)
        {
            var timer = new Timer(interval);
            timer.Elapsed += (sender, args) => SpawnBonus(createBonus);
            _spawnTimers.Add(timer);
        }

        private void SpawnBonus(Func<HealthPack> createBonus)
        {
            var bonusToSpawn = _bonuses.FirstOrDefault(b => !b.IsActive);
            if (bonusToSpawn == null)
            {
                bonusToSpawn = createBonus();
                bonusToSpawn.Initialize();
                _collisionSystem.RegisterEntity(bonusToSpawn);

                _bonuses.Add(bonusToSpawn);
            }

            bonusToSpawn.IsActive = true;
        }
    }
}