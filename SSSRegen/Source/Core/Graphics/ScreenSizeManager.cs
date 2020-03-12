using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Graphics;
using SSSRegen.Source.Core.Utils;

namespace SSSRegen.Source.Core.Graphics
{
    public class ScreenSizeManager : IScreenSizeManager
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly IScreenResolutionConverter _screenResolutionConverter;
        private readonly Vector2 _virtualResolution;

        private Vector2 _screenResolution;
        
        public ScreenSizeManager(GraphicsDeviceManager graphics, IScreenResolutionConverter screenResolutionConverter, Vector2 virtualResolution)
        {
            _graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
            _screenResolutionConverter = screenResolutionConverter ?? throw new ArgumentNullException(nameof(screenResolutionConverter));
            _virtualResolution = virtualResolution;

            ScreenBounds = new Rectangle(0, 0, _virtualResolution.X.ToInt(), _virtualResolution.Y.ToInt());

            //ToDo Check for saved screen resolution preference before defaulting to the device resolution
            _screenResolution = new Vector2(_graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width, _graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height);
            UpdateScreenGraphics();
        }

        public Rectangle ScreenBounds { get; }

        public void SetScreenResolution(ScreenResolutionOption resolutionOption)
        {
            _screenResolution = _screenResolutionConverter.Convert(resolutionOption);
            UpdateScreenGraphics();
        }

        private void UpdateScreenGraphics()
        {
            _graphics.PreferredBackBufferWidth = _screenResolution.X.ToInt();
            _graphics.PreferredBackBufferHeight = _screenResolution.Y.ToInt();
            _graphics.ApplyChanges();
        }

        public void SetFullScreen(bool isFullScreen)
        {
            _graphics.IsFullScreen = isFullScreen;
            _graphics.ApplyChanges();
        }

        public Matrix GetScreenScaleTransformationMatrix()
        {
            var scaleX = _screenResolution.X / _virtualResolution.X;
            var scaleY = _screenResolution.Y / _virtualResolution.Y;

            return Matrix.CreateScale(scaleX, scaleY, 1.0f);
        }
    }
}