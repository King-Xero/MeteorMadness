using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Game.Health;
using SSSRegen.Source.Game.Projectiles;
using SSSRegen.Source.Game.Score;

namespace SSSRegen.Source.Game.Player
{
    public interface IPlayer : IHandleHealth, IHandleScore, IShootProjectiles, IHandleCollisions
    {
        //ToDo Create Ship base class?
        bool IsAccelerating { get; set; }
        float RotationSpeed { get; set; }
        Vector2 ThrusterPosition { get; }
    }
}