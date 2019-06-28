using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Projectiles
{
    public interface IProjectilesManager
    {
        void Initialize();
        void Update(GameTime gameTime);
        void Shoot(IShootProjectiles obj);
        void Draw(GameTime gameTime);
    }
}