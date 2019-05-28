using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IDrawableGameObject : IGameObject
    {
        bool IsVisible { get; set; }
        Vector2 Position { get; set; }
        void Draw(GameTime gameTime);
    }
}