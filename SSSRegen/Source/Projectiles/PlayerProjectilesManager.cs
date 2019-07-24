﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Projectiles
{
    public class PlayerProjectilesManager : IProjectilesManager
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly GameContext _gameContext;

        private List<IGameObject> _bullets;

        public PlayerProjectilesManager(IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory ?? throw new ArgumentNullException(nameof(projectileFactory));
        }

        public void Initialize()
        {
            _bullets = new List<IGameObject>();
            for (int i = 0; i < Math.Round(GameConstants.Projectiles.Player.MaxBulletsOnScreen * 0.8); i++)
            {
                var bullet = _projectileFactory.CreateBullet();
                bullet.Initialize();
                _gameContext.CollisionSystem.RegisterEntity(bullet);
                _bullets.Add(bullet);
            }
        }

        public void Update(IGameTime gameTime)
        {
            foreach (var bullet in _bullets)
            {
                if (bullet.IsActive)
                {
                    bullet.Update(gameTime);
                }
            }
        }

        public void Shoot(IShootProjectiles obj)
        {
            var bulletToShoot = _bullets.FirstOrDefault(b => !b.IsActive);
            if (bulletToShoot == null)
            {
                bulletToShoot = _projectileFactory.CreateBullet();
                
                _bullets.Add(bulletToShoot);
                bulletToShoot.Initialize();
            }
            bulletToShoot.Position = new Vector2(obj.BulletPosition.X - (bulletToShoot.Size.X / 2), obj.BulletPosition.Y);
            bulletToShoot.IsActive = true;
        }

        public void Draw(IGameTime gameTime)
        {
            foreach (var bullet in _bullets)
            {
                if (bullet.IsActive)
                {
                    bullet.Draw(gameTime);
                }
            }
        }
    }
}