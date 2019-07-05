using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IComponent<T>
    {
        void Initialize(T entity);
        void Update(T entity, GameTime gameTime);
    }
}