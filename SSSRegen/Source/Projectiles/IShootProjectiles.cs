using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Projectiles
{
    public interface IShootProjectiles : IGameObject
    {
        void Shoot();
        Vector2 BulletPosition { get; }
    }
}