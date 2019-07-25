using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Utils;

namespace SSSRegen.Source.Core
{
    public class GameGraphics : IGameGraphics
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly IResolution _resolution;

        public GameGraphics(SpriteBatch spriteBatch, IResolution resolution, ITrackingCamera playableCamera)
        {
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
            _resolution = resolution ?? throw new ArgumentNullException(nameof(resolution));
            PlayableCamera = playableCamera ?? throw new ArgumentNullException(nameof(playableCamera));

            ScreenBounds = new Rectangle(0, 0, _resolution.VirtualResolution.X.ToInt(), _resolution.VirtualResolution.Y.ToInt());
        }

        public ITrackingCamera PlayableCamera { get; }

        public Rectangle ScreenBounds { get; }

        public void Draw(ISprite sprite, Rectangle destinationRect, Color color)
        {
            _spriteBatch.Begin(transformMatrix: _resolution.GetTransformationMatrix());
            _spriteBatch.Draw(sprite.Texture, destinationRect, sprite.SourceRectangle, color);
            _spriteBatch.End();
        }

        public void Draw(ISprite sprite, Vector2 position, Color color)
        {
            _spriteBatch.Begin(transformMatrix: _resolution.GetTransformationMatrix());
            _spriteBatch.Draw(sprite.Texture, position, sprite.SourceRectangle, color);
            _spriteBatch.End();
        }

        public void DrawText(IUIText uiText, Vector2 position, Color color)
        {
            _spriteBatch.Begin(transformMatrix: _resolution.GetTransformationMatrix());
            _spriteBatch.DrawString(uiText.Font, uiText.Text, position, color);
            _spriteBatch.End();
        }

        public void DrawPlayable(ISprite sprite, Rectangle destinationRect, Color color)
        {
            throw new NotImplementedException("Method needs to be updated to handle screen scaling");

            //ToDo Update to handle screen scaling
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                null, null, null, null, PlayableCamera.Transform);

            _spriteBatch.Draw(sprite.Texture, destinationRect, sprite.SourceRectangle, color);
            _spriteBatch.End();
        }

        public void DrawPlayable(ISprite sprite, Vector2 position, Color color)
        {
            throw new NotImplementedException("Method needs to be updated to handle screen scaling");

            //ToDo Update to handle screen scaling
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                null, null, null, null, PlayableCamera.Transform);

            _spriteBatch.Draw(sprite.Texture, position, sprite.SourceRectangle, color);
            _spriteBatch.End();
        }

        public void DrawTextPlayable(IUIText uiText, Vector2 position, Color color)
        {
            throw new NotImplementedException("Method needs to be updated to handle screen scaling");

            //ToDo Update to handle screen scaling
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                null, null, null, null, PlayableCamera.Transform);

            _spriteBatch.DrawString(uiText.Font, uiText.Text, position, color);
            _spriteBatch.End();
        }
    }

    public interface IResolution
    {
        Vector2 VirtualResolution { get; }
        Vector2 ActualResolution { get; }
        Matrix GetTransformationMatrix();
    }
}