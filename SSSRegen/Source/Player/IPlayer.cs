using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Health;
using SSSRegen.Source.Projectiles;
using SSSRegen.Source.Score;

namespace SSSRegen.Source.Player
{
    public interface IPlayer : IHandleHealth, IHandleScore, IShootProjectiles, IHandleCollisions
    {
    }
}