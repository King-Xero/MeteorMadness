using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Core.Interfaces.Collision
{
    public interface ICollisionSystem
    {
        void Pause();
        void Resume();

        void RegisterEntity(IHandleCollisions entity);

        void Initialize();
        void Update(IGameTime gameTime);
    }
}