using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IUIText
    {
        SpriteFont Font { get; }
        Color TextColor { get; set; }
        string Text { get; }
        Vector2 Size { get; }
        bool IsVisible { get; set; }
    }
}