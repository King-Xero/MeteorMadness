using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.Enemies;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Physics
{
    public class EnemyPhysicsComponent : IComponent<IEnemy>
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;
        private int _horizontalSpeedMultiplier;
        private int _verticalSpeedMultiplier;
        private Vector2 _movementDirection;

        public EnemyPhysicsComponent(GameContext gameContext, Random random)
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
            if (enemy.Position.Y >= _gameContext.GameGraphics.ScreenBounds.Height ||
                enemy.Position.X >= _gameContext.GameGraphics.ScreenBounds.Width ||
                enemy.Position.X <= _gameContext.GameGraphics.ScreenBounds.Left - enemy.Size.X)
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
                    enemy.MovementSpeed * 0.8f * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());
            }
            else
            {
                //Move the enemy
                enemy.Position += Vector2.Multiply(_movementDirection, enemy.MovementSpeed * 0.8f * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());
            }
        }

        private void Reset(IEnemy enemy)
        {
            enemy.IsActive = false;

            _horizontalSpeedMultiplier = _random.Next(1,3);
            _verticalSpeedMultiplier = _random.Next(1, 5);

            _movementDirection = new Vector2(_horizontalSpeedMultiplier, _verticalSpeedMultiplier);

            enemy.MovementSpeed = 100;

            var enemyPosition = enemy.Position;

            enemyPosition.X = _random.Next(_gameContext.GameGraphics.ScreenBounds.Width - enemy.Bounds.Width);
            enemyPosition.Y = 0;

            enemy.Position = enemyPosition;
        }
    }
}