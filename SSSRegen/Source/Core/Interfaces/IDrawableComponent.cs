using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IDrawableComponent<T> : IComponent<T>
    {
        void Draw(T entity, IGameTime gameTime);
    }
}