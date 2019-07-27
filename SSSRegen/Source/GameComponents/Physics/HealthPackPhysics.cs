using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Utils;

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
            healthPack.Position += Vector2.Multiply(healthPack.MovementDirection, healthPack.MovementSpeed * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());

            //ToDo Resolve collisions
            //If healthPack collides with object, execute only what the healthPack should do.
            //Other objects will handle themselves
            //_gameContext.Collisions.ResolveCollision(healthPack);
        }

        private void Reset(IGameObject healthPack)
        {
            healthPack.IsActive = false;

            var healthPackPosition = healthPack.Position;

            healthPackPosition.X = _random.Next(_gameContext.GameGraphics.ScreenBounds.Width - healthPack.Bounds.Width);
            healthPackPosition.Y = -15;

            healthPack.Position = healthPackPosition;
        }
    }
}