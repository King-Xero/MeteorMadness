using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Player;

namespace SSSRegen.Source.Enemies
{
    public class EnemiesManager : IGameObject
    {
        private readonly IPlayerGameObject[] _players;
        private readonly IEnemyFactory _enemyFactory;
        private Dictionary<string, List<Enemy>> _enemies;

        public EnemiesManager(IPlayerGameObject[] players, IEnemyFactory enemyFactory)
        {
            _players = players ?? throw new ArgumentException(nameof(players));
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));

            Enabled = true;
        }

        public bool Enabled { get; set; }

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

        public void Update(GameTime gameTime)
        {
            foreach (var enemyType in _enemies)
            {
                foreach (var enemy in enemyType.Value.Where(e => e.Enabled))
                {
                    enemy.Update(gameTime);
                    //ToDo Can enemies collide with things other than the player?
                    foreach (var player in _players.Where(e => e.Enabled))
                    {
                        if (enemy.CheckCollision(player))
                        {
                            player.OnCollision(enemy);
                            enemy.OnCollision(player);
                        }
                    }
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var enemyType in _enemies)
            {
                foreach (var enemy in enemyType.Value.Where(e => e.Enabled))
                {
                    enemy.Draw(gameTime);
                }
            }
        }
    }
}