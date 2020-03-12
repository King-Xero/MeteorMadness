using SSSRegen.Source.Core.Collision;
using SSSRegen.Source.Core.Interfaces.Entities;

namespace SSSRegen.Source.Core.Interfaces.Collision
{
    public interface IHandleCollisions : IGameObject
    {
        CollisionLayer CollisionLayer { get; }
        int CollisionDamageAmount { get; }

        void CollidedWith(IHandleCollisions gameObject);
    }
}