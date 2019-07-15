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
            obj.Speed = 400;
        }

        public void Update(IGameObject obj, IGameTime gameTime)
        {
            obj.Position -= Vector2.Multiply(obj.MovementDirection, obj.Speed * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());

            if (!_gameContext.ScreenBounds.Intersects(obj.Bounds))
            {
                obj.IsActive = false;
            }
        }
    }
}