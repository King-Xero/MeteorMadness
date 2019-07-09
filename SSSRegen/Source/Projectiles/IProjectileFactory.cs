using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Projectiles
{
    public interface IProjectileFactory
    {
        IGameObject CreateBullet();
    }
}