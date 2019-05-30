using System;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class MeteorPhysics : IPhysicsComponent
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

        public void Update(IGameObject meteor)
        {
            var meteorPosition = meteor.Position;

            //If the meteor moves out of screen bounds, reset it
            if (meteorPosition.Y >= _gameContext.ScreenBounds.Height ||
                meteorPosition.X >= _gameContext.ScreenBounds.Width ||
                meteorPosition.X <= _gameContext.ScreenBounds.Left - meteor.Width)
            {
                Reset(meteor);
                return;
            }

            //Move the enemy
            meteorPosition.X += meteor.HorizontalVelocity;
            meteorPosition.Y += meteor.VerticalVelocity;

            //ToDo Resolve collisions
            //If meteor collides with object, execute only what the meteor should do.
            //Other objects will handle themselves
            //_gameContext.Collisions.ResolveCollision(meteor);

            meteor.Position = meteorPosition;
        }

        private void Reset(IGameObject meteor)
        {
            meteor.HorizontalVelocity = _random.Next(3) - 1;
            meteor.VerticalVelocity = 1 + _random.Next(4);

            var meteorPosition = meteor.Position;

            meteorPosition.X = _random.Next(_gameContext.ScreenBounds.Width - meteor.Bounds.Width);
            meteorPosition.Y = 0;

            meteor.Position = meteorPosition;
        }
    }
}