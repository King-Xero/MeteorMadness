using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Physics
{
    public class HealthPackPhysicsComponent : IComponent<IGameObject>
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;
        private Vector2 _movementDirection;

        public HealthPackPhysicsComponent(GameContext gameContext, Random random)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public void Initialize(IGameObject healthPack)
        {
            _movementDirection = new Vector2(0, 2);
            healthPack.MovementSpeed = 100;

            //ToDo Execution order of components might cause an error here.
            //Reset uses Bounds to set position. Bounds is set using Height and Width which are initialized in graphics component.
            Reset(healthPack);
        }

        public void Update(IGameObject healthPack, IGameTime gameTime)
        {
            //If the healthPack moves out of screen bounds, reset it
            if (healthPack.Position.Y >= _gameContext.GameGraphics.ScreenBounds.Height)
            {
                Reset(healthPack);
                return;
            }

            //Move the healthPack
            healthPack.Position += Vector2.Multiply(_movementDirection, healthPack.MovementSpeed * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());
        }

        private void Reset(IGameObject healthPack)
        {
            healthPack.IsActive = false;

            var healthPackPosition = healthPack.Position;

            healthPackPosition.X = _random.Next(_gameContext.GameGraphics.ScreenBounds.Width);
            healthPackPosition.Y = -15;

            healthPack.Position = healthPackPosition;
        }
    }
}