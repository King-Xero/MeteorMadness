using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface ISprite
    {
        Texture2D Texture { get; }
        Rectangle? SourceRectangle { get; }
        Vector2 Size { get; }
        bool IsVisible { get; set; }
    }
}