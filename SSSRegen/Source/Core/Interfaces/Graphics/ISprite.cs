using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Core.Interfaces.Graphics
{
    public interface ISprite
    {
        Texture2D Texture { get; }
        Rectangle? SourceRectangle { get; }
        Vector2 Size { get; }
        Vector2 Origin { get; }
        bool IsVisible { get; set; }
    }
}