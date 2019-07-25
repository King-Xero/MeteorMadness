using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class GameGraphics : IGameGraphics
    {
        private readonly SpriteBatch _spriteBatch;
        
        public GameGraphics(SpriteBatch spriteBatch, TrackingCamera2D playableCamera)
        {
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
            PlayableCamera = playableCamera ?? throw new ArgumentNullException(nameof(playableCamera));
        }

        public ITrackingCamera PlayableCamera { get; }

        public void Draw(ISprite sprite, Rectangle destinationRect, Color color)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(sprite.Texture, destinationRect, sprite.SourceRectangle, color);
            _spriteBatch.End();
        }

        public void Draw(ISprite sprite, Vector2 position, Color color)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(sprite.Texture, position, sprite.SourceRectangle, color);
            _spriteBatch.End();
        }

        public void DrawText(IUIText uiText, Vector2 position, Color color)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(uiText.Font, uiText.Text, position, color);
            _spriteBatch.End();
        }

        public void DrawPlayable(ISprite sprite, Rectangle destinationRect, Color color)
        {
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                null, null, null, null, PlayableCamera.Transform);

            _spriteBatch.Draw(sprite.Texture, destinationRect, sprite.SourceRectangle, color);
            _spriteBatch.End();
        }

        public void DrawPlayable(ISprite sprite, Vector2 position, Color color)
        {
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                null, null, null, null, PlayableCamera.Transform);

            _spriteBatch.Draw(sprite.Texture, position, sprite.SourceRectangle, color);
            _spriteBatch.End();
        }

        public void DrawTextPlayable(IUIText uiText, Vector2 position, Color color)
        {
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                null, null, null, null, PlayableCamera.Transform);

            _spriteBatch.DrawString(uiText.Font, uiText.Text, position, color);
            _spriteBatch.End();
        }
    }
}