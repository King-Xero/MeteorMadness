using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameObjectManager
    {
        void Initialize();
        void Update(IGameTime gameTime);
        void Draw(IGameTime gameTime);
    }
}