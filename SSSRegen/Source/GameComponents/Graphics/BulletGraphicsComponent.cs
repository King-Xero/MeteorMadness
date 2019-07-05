using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public class BulletGraphicsComponent : IDrawableComponent<IGameObject>
    {
        private readonly IGameGraphics _gameGraphics;
        private readonly ISprite _bulletSprite;

        public BulletGraphicsComponent(IGameGraphics gameGraphics, ISprite bulletSprite)
        {
            _gameGraphics = gameGraphics;
            _bulletSprite = bulletSprite;
        }

        public void Initialize(IGameObject entity)
        {
            entity.Size = _bulletSprite.Size;
        }

        public void Update(IGameObject entity, GameTime gameTime)
        {
            entity.Size = _bulletSprite.Size;
        }

        public void Draw(IGameObject entity, GameTime gameTime)
        {
            _gameGraphics.Draw(_bulletSprite, entity.Bounds, Color.White);
        }
    }
}