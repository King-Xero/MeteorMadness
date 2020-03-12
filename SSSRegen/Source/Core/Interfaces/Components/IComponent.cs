using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Core.Interfaces.Components
{
    public interface IComponent<T>
    {
        void Initialize(T entity);
        void Update(T entity, IGameTime gameTime);
    }
}