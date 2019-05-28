using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface ICollidable
    {
        Rectangle CollisionBounds { get; }
        bool CheckCollision(ICollidable col);
        void OnCollision(ICollidable col);
    }
}