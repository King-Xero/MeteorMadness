using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Enemies;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Utils;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class EnemyPhysics : IComponent<IEnemy>
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;
        private int _horizontalSpeedMultiplier;
        private int _verticalSpeedMultiplier;

        public EnemyPhysics(GameContext gameContext, Random random)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public void Initialize(IEnemy enemy)
        {
            //ToDo Execution order of components might cause an error here.
            //Reset uses Bounds to set position. Bounds is set using Height and Width which are initialized in graphics component.
            Reset(enemy);
        }

        public void Update(IEnemy enemy, IGameTime gameTime)
        {
            //If the enemy moves out of screen bounds, reset it
            if (enemy.Position.Y >= _gameContext.ScreenBounds.Height ||
                enemy.Position.X >= _gameContext.ScreenBounds.Width ||
                enemy.Position.X <= _gameContext.ScreenBounds.Left - enemy.Size.X)
            {
                Reset(enemy);
                return;
            }

            if (enemy.Target != null)
            {
                var movementDirection = Vector2.Subtract(enemy.Target.Position, enemy.Position);

                movementDirection.Normalize();

                movementDirection.X *= _horizontalSpeedMultiplier * 10;
                movementDirection.Y *= _verticalSpeedMultiplier;

                //Move towards target
                enemy.Position += Vector2.Multiply(movementDirection,
                    enemy.Speed * 0.8f * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());
            }
            else
            {
                //Move the enemy
                enemy.Position += Vector2.Multiply(enemy.MovementDirection, enemy.Speed * 0.8f * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());
            }
        }

        private void Reset(IEnemy enemy)
        {
            enemy.IsActive = false;

            _horizontalSpeedMultiplier = _random.Next(1,3);
            _verticalSpeedMultiplier = _random.Next(1, 5);

            enemy.MovementDirection = new Vector2(_horizontalSpeedMultiplier, _verticalSpeedMultiplier);

            enemy.Speed = 100;

            var enemyPosition = enemy.Position;

            enemyPosition.X = _random.Next(_gameContext.ScreenBounds.Width - enemy.Bounds.Width);
            enemyPosition.Y = 0;

            enemy.Position = enemyPosition;
        }
    }
}