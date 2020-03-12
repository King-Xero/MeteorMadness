using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Game.Player;

namespace SSSRegen.Source.Game.GameComponents.Physics
{
    public interface IPlayerPhysicsComponent : IComponent<IPlayer>
    {
        Vector2 ThrustingVelocity { get; }
    }
}