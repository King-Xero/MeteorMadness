using System;
using System.Collections.Generic;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Enemies
{
    public class EnemiesManager : IGameObjectManager
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICollisionSystem _collisionSystem;
        private Dictionary<string, List<Enemy>> _enemies;

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
                {GameConstants.Enemies.EnemyBoss.Name, new List<Enemy>()}
            };

            for (var i = 0; i < GameConstants.Enemies.Enemy1.InitialCount; i++)
            {
                var enemy = _enemyFactory.CreateEnemy1();
                enemy.Initialize();
                _collisionSystem.RegisterEntity(enemy);

                _enemies[GameConstants.Enemies.Enemy1.Name].Add(enemy);
            }
            for (var i = 0; i < GameConstants.Enemies.Enemy2.InitialCount; i++)
            {
                var enemy = _enemyFactory.CreateEnemy2();
                enemy.Initialize();
                _collisionSystem.RegisterEntity(enemy);

                _enemies[GameConstants.Enemies.Enemy2.Name].Add(enemy);
            }
            for (var i = 0; i < GameConstants.Enemies.Enemy3.InitialCount; i++)
            {
                var enemy = _enemyFactory.CreateEnemy3();
                enemy.Initialize();
                _collisionSystem.RegisterEntity(enemy);

                _enemies[GameConstants.Enemies.Enemy3.Name].Add(enemy);
            }
        }

        public void Update(IGameTime gameTime)
        {
            foreach (var enemyType in _enemies)
            {
                foreach (var enemy in enemyType.Value)
                {
                    enemy.Update(gameTime);
                }
            }
        }

        public void Draw(IGameTime gameTime)
        {
            foreach (var enemyType in _enemies)
            {
                foreach (var enemy in enemyType.Value)
                {
                    enemy.Draw(gameTime);
                }
            }
        }
    }
}