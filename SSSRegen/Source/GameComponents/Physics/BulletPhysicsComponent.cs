using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Utils;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class BulletPhysicsComponent : IComponent<IGameObject>
    {
        private readonly GameContext _gameContext;

        public BulletPhysicsComponent(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameObject obj)
        {
            obj.MovementDirection = new Vector2(0, 1);
        }

        public void Update(IGameObject bullet, IGameTime gameTime)
        {
            //Rotation needs a 90 degree offset for upright sprites
            bullet.MovementDirection = new Vector2(
                Math.Cos(MathHelper.ToRadians(90) - bullet.Rotation).ToFloat(),
                -Math.Sin(MathHelper.ToRadians(90) - bullet.Rotation).ToFloat());

            bullet.Position += Vector2.Multiply(bullet.MovementDirection, bullet.MovementSpeed * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());

            if (!_gameContext.GameGraphics.ScreenBounds.Intersects(bullet.Bounds))
            {
                bullet.IsActive = false;
            }
        }
    }
}