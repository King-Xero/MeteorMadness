using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Entities;

namespace SSSRegen.Source.Game.Projectiles
{
    public interface IShootProjectiles : IGameObject
    {
        void Shoot();
    }
}