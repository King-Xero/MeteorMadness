using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Projectiles
{
    public class PlayerProjectilesManager : IProjectilesManager
    {
        private readonly GameContext _gameContext;

        private List<IProjectile> _bullets;

        public PlayerProjectilesManager(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize()
        {
            _bullets = new List<IProjectile>();
            for (int i = 0; i < Math.Round(GameConstants.Projectiles.Player.MaxBulletsOnScreen * 0.8); i++)
            {
                var bullet = _gameContext.Factories.ProjectileFactory.CreateBullet();
                bullet.Initialize();
                _bullets.Add(bullet);
            }
        }

        public void Update(GameTime gameTime)
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
                bulletToShoot = _gameContext.Factories.ProjectileFactory.CreateBullet();
                bulletToShoot.Initialize();

                _bullets.Add(bulletToShoot);
            }

            bulletToShoot.Position = obj.BulletPosition;
            bulletToShoot.IsActive = true;
        }

        public void Draw(GameTime gameTime)
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