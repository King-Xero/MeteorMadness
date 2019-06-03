using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameGraphics
    {
        void Draw(ISprite sprite, Rectangle destinationRect, Color color);
    }
}