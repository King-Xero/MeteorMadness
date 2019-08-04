using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Physics
{
    public class MeteorPhysicsComponent : IComponent<IGameObject>
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;
        private Vector2 _movementDirection;

        public MeteorPhysicsComponent(GameContext gameContext, Random random)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public void Initialize(IGameObject meteor)
        {
            //ToDo Execution order of components might cause an error here.
            //Reset uses Bounds to set position. Bounds is set using Height and Width which are initialized in graphics component.
            Reset(meteor);
        }

        public void Update(IGameObject meteor, IGameTime gameTime)
        {
            //If the meteor moves out of screen bounds, reset it
            if (meteor.Position.Y >= _gameContext.GameGraphics.ScreenBounds.Height ||
                meteor.Position.X >= _gameContext.GameGraphics.ScreenBounds.Width ||
                meteor.Position.X <= _gameContext.GameGraphics.ScreenBounds.Left - meteor.Size.X)
            {
                Reset(meteor);
                return;
            }

            //Move the enemy
            meteor.Position += Vector2.Multiply(_movementDirection, meteor.MovementSpeed * 0.8f * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());
        }

        private void Reset(IGameObject meteor)
        {
            meteor.IsActive = false;

            _movementDirection = new Vector2(_random.Next(3) - 1, 1 + _random.Next(4));
            meteor.MovementSpeed = 100;

            var meteorPosition = meteor.Position;

            meteorPosition.X = _random.Next(_gameContext.GameGraphics.ScreenBounds.Width);
            meteorPosition.Y = 0;

            meteor.Position = meteorPosition;
        }
    }
}