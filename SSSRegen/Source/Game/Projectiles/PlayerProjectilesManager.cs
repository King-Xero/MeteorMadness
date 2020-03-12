using System;
using System.Collections.Generic;
using System.Linq;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Player;

namespace SSSRegen.Source.Game.Projectiles
{
    public class PlayerProjectilesManager : IProjectilesManager
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly ICollisionSystem _collisionSystem;

        private List<IGameObject> _bullets;

        public PlayerProjectilesManager(IProjectileFactory projectileFactory, ICollisionSystem collisionSystem)
        {
            _projectileFactory = projectileFactory ?? throw new ArgumentNullException(nameof(projectileFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
        }

        public void Initialize()
        {
            _bullets = new List<IGameObject>();
            for (int i = 0; i < Math.Round(GameConstants.ProjectileConstants.MaxBulletsOnScreen * 0.8); i++)
            {
                var bullet = _projectileFactory.CreateBullet();
                bullet.Initialize();
                _collisionSystem.RegisterEntity(bullet);
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

        public void Shoot(IPlayer obj)
        {
            var bulletToShoot = _bullets.FirstOrDefault(b => !b.IsActive);
            if (bulletToShoot == null)
            {
                bulletToShoot = _projectileFactory.CreateBullet();
                
                _bullets.Add(bulletToShoot);
                bulletToShoot.Initialize();
            }

            bulletToShoot.MovementSpeed = obj.ThrustingVelocity.Length() + GameConstants.ProjectileConstants.Bullet3Constants.BulletSpeed;
            bulletToShoot.Rotation = obj.Rotation;
            bulletToShoot.Position = obj.Position;
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