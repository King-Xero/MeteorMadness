using System.Collections.Generic;

namespace SSSRegen.Source.Core.Interfaces
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