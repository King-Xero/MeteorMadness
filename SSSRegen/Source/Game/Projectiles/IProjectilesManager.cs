using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Game.Player;

namespace SSSRegen.Source.Game.Projectiles
{
    public interface IProjectilesManager
    {
        void Initialize();
        void Update(IGameTime gameTime);
        void Shoot(IPlayer obj);
        void Draw(IGameTime gameTime);
    }
}