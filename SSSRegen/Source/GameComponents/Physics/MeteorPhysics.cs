using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Utils;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class MeteorPhysics : IComponent<IGameObject>
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;

        public MeteorPhysics(GameContext gameContext, Random random)
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
            meteor.Position += Vector2.Multiply(meteor.MovementDirection, meteor.Speed * 0.8f * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());
        }

        private void Reset(IGameObject meteor)
        {
            meteor.IsActive = false;

            meteor.MovementDirection = new Vector2(_random.Next(3) - 1, 1 + _random.Next(4));
            meteor.Speed = 100;

            var meteorPosition = meteor.Position;

            meteorPosition.X = _random.Next(_gameContext.GameGraphics.ScreenBounds.Width - meteor.Bounds.Width);
            meteorPosition.Y = 0;

            meteor.Position = meteorPosition;
        }
    }
}