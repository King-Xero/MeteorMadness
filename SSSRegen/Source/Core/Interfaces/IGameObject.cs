using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameObject
    {
        bool IsEnabled { get; set; }
        void Initialize();
        void Update(GameTime gameTime);
    }
}