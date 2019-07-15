namespace SSSRegen.Source.Core.Interfaces
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