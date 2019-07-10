using SSSRegen.Source.Collision;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IHandleCollisions : IGameObject
    {
        CollisionLayer CollisionLayer { get; }

        void CollidedWith(IHandleCollisions gameObject);
    }
}