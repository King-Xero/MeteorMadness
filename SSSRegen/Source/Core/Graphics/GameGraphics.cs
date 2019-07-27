using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Core.Interfaces.Graphics;

namespace SSSRegen.Source.Core.Graphics
{
    public class GameGraphics : IGameGraphics
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly IScreenSizeManager _screenSizeManager;

        public GameGraphics(SpriteBatch spriteBatch, IScreenSizeManager screenSizeManager, ITrackingCamera playableCamera)
        {
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
            _screenSizeManager = screenSizeManager ?? throw new ArgumentNullException(nameof(screenSizeManager));
            PlayableCamera = playableCamera ?? throw new ArgumentNullException(nameof(playableCamera));
        }

        public ITrackingCamera PlayableCamera { get; }
        public void SetResolution(ScreenResolutionOption resolutionOption)
        {
            _screenSizeManager.SetScreenResolution(resolutionOption);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            _screenSizeManager.SetFullScreen(isFullScreen);
        }

        public Rectangle ScreenBounds => _screenSizeManager.ScreenBounds;

        public void Draw(ISprite sprite, Rectangle destinationRect, Color color)
        {
            _spriteBatch.Begin(transformMatrix: _screenSizeManager.GetScreenScaleTransformationMatrix());
            _spriteBatch.Draw(sprite.Texture, destinationRect, sprite.SourceRectangle, color);
            _spriteBatch.End();
        }

        public void Draw(ISprite sprite, Vector2 position, Color color)
        {
            _spriteBatch.Begin(transformMatrix: _screenSizeManager.GetScreenScaleTransformationMatrix());
            _spriteBatch.Draw(sprite.Texture, position, sprite.SourceRectangle, color);
            _spriteBatch.End();
        }

        public void DrawText(IUIText uiText, Vector2 position, Color color)
        {
            _spriteBatch.Begin(transformMatrix: _screenSizeManager.GetScreenScaleTransformationMatrix());
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
}