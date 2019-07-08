using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Utils.Extensions;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class HealthPackPhysics : IComponent<IGameObject>
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
            healthPack.MovementDirection = new Vector2(0, 2);
            healthPack.Speed = 100;

            //ToDo Execution order of components might cause an error here.
            //Reset uses Bounds to set position. Bounds is set using Height and Width which are initialized in graphics component.
            Reset(healthPack);
        }

        public void Update(IGameObject healthPack, GameTime gameTime)
        {
            var healthPackPosition = healthPack.Position;

            //If the healthPack moves out of screen bounds, reset it
            if (healthPackPosition.Y >= _gameContext.ScreenBounds.Height)
            {
                Reset(healthPack);
                return;
            }

            //Move the healthPack
            healthPackPosition += Vector2.Multiply(healthPack.MovementDirection, healthPack.Speed * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());

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