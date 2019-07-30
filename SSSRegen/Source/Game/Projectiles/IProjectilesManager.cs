using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Game.Projectiles
{
    public interface IProjectilesManager
    {
        void Initialize();
        void Update(IGameTime gameTime);
        void Shoot(IShootProjectiles obj);
        void Draw(IGameTime gameTime);
    }
}