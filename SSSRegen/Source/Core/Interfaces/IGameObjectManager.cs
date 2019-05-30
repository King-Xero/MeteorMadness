using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameObjectManager
    {
        void Initialize();
        void Update();
        void Draw(GameTime gameTime);
    }
}