using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Game.Health;
using SSSRegen.Source.Game.Projectiles;
using SSSRegen.Source.Game.Score;

namespace SSSRegen.Source.Game.Player
{
    public interface IPlayer : IHandleHealth, IHandleScore, IShootProjectiles, IHandleCollisions
    {
    }
}