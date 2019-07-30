using System;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Game.GameComponents.Graphics;
using SSSRegen.Source.Game.GameComponents.Physics;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.Projectiles
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
                GameConstants.ProjectileConstants.Bullet3Constants.DamageAmount,
                new BulletPhysicsComponent(_gameContext),
                CreateBulletGraphics());
        }

        private IDrawableComponent<IGameObject> CreateBulletGraphics()
        {
            var bulletTexture = _gameContext.AssetManager.GetTexture(GameConstants.ProjectileConstants.Bullet3Constants.Textures.RedTextureName);
            var bulletSprite = new Sprite(bulletTexture);

            return new BulletGraphicsComponent(_gameContext.GameGraphics, bulletSprite);
        }
    }
}