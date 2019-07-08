using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Projectiles
{
    public interface IProjectilesManager
    {
        void Initialize();
        void Update(IGameTime gameTime);
        void Shoot(IShootProjectiles obj);
        void Draw(IGameTime gameTime);
    }
}