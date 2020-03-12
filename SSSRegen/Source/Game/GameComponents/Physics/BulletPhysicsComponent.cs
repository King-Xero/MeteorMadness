using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Physics
{
    public class BulletPhysicsComponent : IComponent<IGameObject>
    {
        private readonly GameContext _gameContext;
        private Vector2 _movementDirection;

        public BulletPhysicsComponent(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameObject obj)
        {
        }

        public void Update(IGameObject bullet, IGameTime gameTime)
        {
            //Rotation needs a 90 degree offset for upright sprites
            _movementDirection = new Vector2(
                Math.Cos(MathHelper.ToRadians(90) - bullet.Rotation).ToFloat(),
                -Math.Sin(MathHelper.ToRadians(90) - bullet.Rotation).ToFloat());

            bullet.Position += Vector2.Multiply(_movementDirection, bullet.MovementSpeed * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());

            if (!_gameContext.GameGraphics.ScreenBounds.Intersects(bullet.Bounds))
            {
                bullet.IsActive = false;
            }
        }
    }
}