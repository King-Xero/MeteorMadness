using System.Collections.Generic;
using SSSRegen.Source.Core.Interfaces.Entities;

namespace SSSRegen.Source.Core.Interfaces.GameStateMachine
{
    public interface IGameState
    {
        IEnumerable<IGameObject> GameObjects { get; }

        void Initialize();
        void Update(IGameTime gameTime);
        void Draw(IGameTime gameTime);
        void Pause();
        void Resume();
    }
}