using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface ISprite
    {
        bool IsVisible { get; set; }
        Rectangle Bounds { get; }
        Vector2 Position { get; set; }
        void Draw(GameTime gameTime);
    }
}