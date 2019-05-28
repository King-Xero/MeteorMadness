using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface ISpriteBatch
    {
        void Draw(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color color);
    }
}