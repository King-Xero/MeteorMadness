using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Game.Health;

namespace SSSRegen.Source.Game.Enemies
{
    public interface IEnemy : IHandleHealth, IHandleCollisions
    {
        IGameObject Target { get; }
    }
}