using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IUIText
    {
        SpriteFont Font { get; }
        string Text { get; }
    }
}