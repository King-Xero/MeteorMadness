using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Core.Interfaces.Components
{
    public interface IDrawableComponent<T> : IComponent<T>
    {
        void Draw(T entity, IGameTime gameTime);
    }
}