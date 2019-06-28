using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Projectiles
{
    public interface IShootProjectiles
    {
        void Shoot();
        Vector2 BulletPosition { get; }
    }
}