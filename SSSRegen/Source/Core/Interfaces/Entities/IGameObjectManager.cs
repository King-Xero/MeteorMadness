using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Core.Interfaces.Entities
{
    public interface IGameObjectManager
    {
        void Initialize();
        void Update(IGameTime gameTime);
        void Draw(IGameTime gameTime);
        void Pause();
        void Resume();
    }
}