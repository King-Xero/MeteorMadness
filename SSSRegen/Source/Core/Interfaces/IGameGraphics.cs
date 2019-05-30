using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameGraphics
    {
        void Draw(Sprite sprite, Rectangle destinationRect, Color color);
    }
}