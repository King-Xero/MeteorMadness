using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface ICollisionGameObject : IGameObject
    {
        Rectangle CollisionBounds { get; }
        bool CheckCollision(ICollisionGameObject gameObject);
        void OnCollision(ICollisionGameObject col);
    }
}