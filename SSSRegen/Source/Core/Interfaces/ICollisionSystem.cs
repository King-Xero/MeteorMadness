namespace SSSRegen.Source.Core.Interfaces
{
    public interface ICollisionSystem
    {
        void Pause();
        void Resume();

        void RegisterEntity(IGameObject entity);

        void Initialize();
        void Update(IGameTime gameTime);
    }
}