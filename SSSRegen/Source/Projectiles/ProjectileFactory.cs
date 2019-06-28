﻿using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Projectiles
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;

        public ProjectileFactory(GameContext gameContext, Random random)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public IProjectile CreateBullet()
        {
            return new Bullet(
                new NullGameObjectInputComponent(),
                new BulletPhysicsComponent(_gameContext),
                CreateBulletGraphics());
        }

        private IGraphicsComponent<IGameObject> CreateBulletGraphics()
        {
            var bulletTexture = _gameContext.AssetManager.GetTexture(GameConstants.Projectiles.BulletTextureName);
            var bulletSprite = new Sprite(bulletTexture);

            return new BulletGraphicsComponent(_gameContext.GameGraphics, bulletSprite);
        }
    }
}