using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Enemies
{
    public class EnemiesManager : IGameObjectManager
    {
        private readonly IEnemyFactory _enemyFactory;
        private Dictionary<string, List<Enemy>> _enemies;

        public EnemiesManager(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
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
                _enemies[GameConstants.Enemies.Enemy1.Name].Add(_enemyFactory.CreateEnemy1());
            }
            for (var i = 0; i < GameConstants.Enemies.Enemy2.InitialEnemyCount; i++)
            {
                _enemies[GameConstants.Enemies.Enemy2.Name].Add(_enemyFactory.CreateEnemy2());
            }
            for (var i = 0; i < GameConstants.Enemies.Enemy3.InitialCount; i++)
            {
                _enemies[GameConstants.Enemies.Enemy3.Name].Add(_enemyFactory.CreateEnemy3());
            }
            for (var i = 0; i < GameConstants.Enemies.EnemyBoss.InitialCount; i++)
            {
                _enemies[GameConstants.Enemies.EnemyBoss.Name].Add(_enemyFactory.CreateEnemyBoss());
            }

            foreach (var enemyType in _enemies)
            {
                foreach (var enemy in enemyType.Value)
                {
                    enemy.Initialize();
                }
            }
        }

        public void Update()
        {
            foreach (var enemyType in _enemies)
            {
                foreach (var enemy in enemyType.Value)
                {
                    enemy.Update();
                }
            }
        }

        public void Draw(GameTime gameTime)
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