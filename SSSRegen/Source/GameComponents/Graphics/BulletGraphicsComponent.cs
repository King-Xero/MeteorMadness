using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Core.Interfaces.Graphics;

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

        public void Initialize(IGameObject bullet)
        {
            bullet.Size = _bulletSprite.Size;
            bullet.Origin = _bulletSprite.Origin;
        }

        public void Update(IGameObject bullet, IGameTime gameTime)
        {
            bullet.Size = _bulletSprite.Size;
        }

        public void Draw(IGameObject bullet, IGameTime gameTime)
        {
            _gameGraphics.Draw(_bulletSprite, bullet.Position, Color.White, bullet.Rotation, bullet.Origin);
        }
    }
}