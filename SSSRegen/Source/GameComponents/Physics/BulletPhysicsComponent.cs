using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Projectiles;
using SSSRegen.Source.Utils.Extensions;

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
            obj.Velocity = new Vector2(0, 1);
            obj.Speed = 400;
        }

        public void Update(IGameObject obj, GameTime gameTime)
        {
            var position = obj.Position;

            position -= Vector2.Multiply(obj.Velocity, obj.Speed * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());

            obj.Position = position;

            if (!_gameContext.ScreenBounds.Intersects(obj.Bounds))
            {
                var proj = (IProjectile) obj;
                proj.IsActive = false;
            }
        }
    }
}