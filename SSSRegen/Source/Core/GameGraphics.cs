using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class GameGraphics : IGameGraphics
    {
        private readonly SpriteBatch _spriteBatch;

        public GameGraphics(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
        }

        public void Draw(ISprite sprite, Rectangle destinationRect, Color color)
        {
            _spriteBatch.Draw(sprite.Texture, destinationRect, sprite.SourceRectangle, color);
        }
    }
}