using System;
using System.Collections.Generic;
using System.Linq;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Enemies
{
    public class EnemiesManager : IGameObjectManager
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICollisionSystem _collisionSystem;

        private Dictionary<string, List<Enemy>> _enemies;
        private List<PausableTimer> _spawnTimers;
        private bool _isPaused;

        public EnemiesManager(IEnemyFactory enemyFactory, ICollisionSystem collisionSystem)
        {
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
        }

        public void Initialize()
        {
            _enemies = new Dictionary<string, List<Enemy>>
            {
                {GameConstants.Enemies.Enemy1.Name, new List<Enemy>()},
                {GameConstants.Enemies.Enemy2.Name, new List<Enemy>()},
                {GameConstants.Enemies.Enemy3.Name, new List<Enemy>()},
            };

            _spawnTimers = new List<PausableTimer>();

            for (var i = 0; i < GameConstants.Enemies.Enemy1.InitialCount; i++)
            {
                var enemy = _enemyFactory.CreateEnemy1();
                _collisionSystem.RegisterEntity(enemy);
                _enemies[GameConstants.Enemies.Enemy1.Name].Add(enemy);
            }

            AddSpawnTimer(5000, _enemyFactory.CreateEnemy1, GameConstants.Enemies.Enemy1.Name);

            for (var i = 0; i < GameConstants.Enemies.Enemy2.InitialCount; i++)
            {
                var enemy = _enemyFactory.CreateEnemy2();
                _collisionSystem.RegisterEntity(enemy);
                _enemies[GameConstants.Enemies.Enemy2.Name].Add(enemy);
            }

            AddSpawnTimer(7000, _enemyFactory.CreateEnemy2, GameConstants.Enemies.Enemy2.Name);

            for (var i = 0; i < GameConstants.Enemies.Enemy3.InitialCount; i++)
            {
                var enemy = _enemyFactory.CreateEnemy3();
                _collisionSystem.RegisterEntity(enemy);
                _enemies[GameConstants.Enemies.Enemy3.Name].Add(enemy);
            }

            AddSpawnTimer(15000, _enemyFactory.CreateEnemy3, GameConstants.Enemies.Enemy3.Name);

            foreach (var spawnTimer in _spawnTimers)
            {
                spawnTimer.Start();
            }
        }

        public void Update(IGameTime gameTime)
        {
            if (_isPaused) return;

            foreach (var enemyType in _enemies)
            {
                foreach (var enemy in enemyType.Value)
                {
                    if (enemy.IsActive)
                    {
                        enemy.Update(gameTime);
                    }
                }
            }
        }

        public void Draw(IGameTime gameTime)
        {
            foreach (var enemyType in _enemies)
            {
                foreach (var enemy in enemyType.Value)
                {
                    if (enemy.IsActive)
                    {
                        enemy.Draw(gameTime);
                    }
                }
            }
        }

        public void Pause()
        {
            _isPaused = true;
            foreach (var spawnTimer in _spawnTimers)
            {
                spawnTimer.Pause();
            }
        }

        public void Resume()
        {
            _isPaused = false;
            foreach (var spawnTimer in _spawnTimers)
            {
                spawnTimer.Resume();
            }
        }

        private void AddSpawnTimer(int interval, Func<Enemy> createEnemy, string enemyName)
        {
            var timer = new PausableTimer(interval);
            timer.Elapsed += (sender, args) => SpawnEnemy(createEnemy, enemyName);
            _spawnTimers.Add(timer);
        }

        private void SpawnEnemy(Func<Enemy> createEnemy, string enemyName)
        {
            var enemyToSpawn = _enemies[enemyName].FirstOrDefault(b => !b.IsActive);
            if (enemyToSpawn == null)
            {
                enemyToSpawn = createEnemy();
                _collisionSystem.RegisterEntity(enemyToSpawn);

                _enemies[enemyName].Add(enemyToSpawn);
            }
            enemyToSpawn.Initialize();

            enemyToSpawn.IsActive = true;
        }
    }
}