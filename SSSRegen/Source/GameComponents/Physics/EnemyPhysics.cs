using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Utils.Extensions;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class EnemyPhysics : IPhysicsComponent
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;

        public EnemyPhysics(GameContext gameContext, Random random)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public void Initialize(IGameObject enemy)
        {
            //ToDo Execution order of components might cause an error here.
            //Reset uses Bounds to set position. Bounds is set using Height and Width which are initialized in graphics component.
            Reset(enemy);
        }

        public void Update(IGameObject enemy, GameTime gameTime)
        {
            var enemyPosition = enemy.Position;

            //If the enemy moves out of screen bounds, reset it
            if (enemyPosition.Y >= _gameContext.ScreenBounds.Height ||
                enemyPosition.X >= _gameContext.ScreenBounds.Width ||
                enemyPosition.X <= _gameContext.ScreenBounds.Left - enemy.Size.X)
            {
                Reset(enemy);
                return;
            }

            //Move the enemy
            enemyPosition += Vector2.Multiply(enemy.Velocity, enemy.Speed * 0.8f * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());

            //ToDo Resolve collisions
            //If enemy collides with object, execute only what the enemy should do.
            //Other objects will handle themselves
            //_gameContext.Collisions.ResolveCollision(enemy);

            enemy.Position = enemyPosition;
        }

        private void Reset(IGameObject enemy)
        {
            enemy.Velocity = new Vector2(_random.Next(3) - 1, 1 + _random.Next(4));
            enemy.Speed = 100;

            var enemyPosition = enemy.Position;

            enemyPosition.X = _random.Next(_gameContext.ScreenBounds.Width - enemy.Bounds.Width);
            enemyPosition.Y = 0;

            enemy.Position = enemyPosition;
        }
    }
}