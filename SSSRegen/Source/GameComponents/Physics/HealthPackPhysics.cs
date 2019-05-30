using System;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class HealthPackPhysics : IPhysicsComponent
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;

        public HealthPackPhysics(GameContext gameContext, Random random)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public void Initialize(IGameObject healthPack)
        {
            healthPack.VerticalVelocity = 2;

            //ToDo Execution order of components might cause an error here.
            //Reset uses Bounds to set position. Bounds is set using Height and Width which are initialized in graphics component.
            Reset(healthPack);
        }

        public void Update(IGameObject healthPack)
        {
            var healthPackPosition = healthPack.Position;

            //If the healthPack moves out of screen bounds, reset it
            if (healthPackPosition.Y >= _gameContext.ScreenBounds.Height)
            {
                Reset(healthPack);
                return;
            }

            //Move the healthPack
            healthPackPosition.Y += healthPack.VerticalVelocity;

            //ToDo Resolve collisions
            //If healthPack collides with object, execute only what the healthPack should do.
            //Other objects will handle themselves
            //_gameContext.Collisions.ResolveCollision(healthPack);

            healthPack.Position = healthPackPosition;
        }

        private void Reset(IGameObject healthPack)
        {
            var healthPackPosition = healthPack.Position;

            healthPackPosition.X = _random.Next(_gameContext.ScreenBounds.Width - healthPack.Bounds.Width);
            healthPackPosition.Y = -15;

            healthPack.Position = healthPackPosition;
        }
    }
}