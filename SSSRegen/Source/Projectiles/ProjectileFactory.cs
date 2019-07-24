using System;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Projectiles
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;

        public ProjectileFactory(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = gameContext.Random ?? throw new ArgumentNullException(nameof(gameContext.Random));
        }

        public Bullet CreateBullet()
        {
            return new Bullet(
                _gameContext,
                GameConstants.Projectiles.Bullet3.DamageAmount,
                new BulletPhysicsComponent(_gameContext),
                CreateBulletGraphics());
        }

        private IDrawableComponent<IGameObject> CreateBulletGraphics()
        {
            var bulletTexture = _gameContext.AssetManager.GetTexture(GameConstants.Projectiles.Bullet3.Textures.RedTextureName);
            var bulletSprite = new Sprite(bulletTexture);

            return new BulletGraphicsComponent(_gameContext.GameGraphics, bulletSprite);
        }
    }
}