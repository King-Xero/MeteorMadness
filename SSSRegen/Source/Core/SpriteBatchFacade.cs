using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class SpriteBatchFacade : ISpriteBatch
    {
        private readonly SpriteBatch _spriteBatch;

        public SpriteBatchFacade(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color color)
        {
            _spriteBatch.Draw(texture, position, sourceRectangle, color);
        }
    }
}