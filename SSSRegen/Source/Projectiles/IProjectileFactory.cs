using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Projectiles
{
    public interface IProjectileFactory
    {
        IProjectile CreateBullet();
    }
}