using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Health;

namespace SSSRegen.Source.Enemies
{
    public interface IEnemy : IHandleHealth, IHandleCollisions
    {
        IGameObject Target { get; }
    }
}