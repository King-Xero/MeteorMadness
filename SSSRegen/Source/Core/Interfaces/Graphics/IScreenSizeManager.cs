using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Graphics;

namespace SSSRegen.Source.Core.Interfaces.Graphics
{
    public interface IScreenSizeManager
    {
        Rectangle ScreenBounds { get; }

        void SetScreenResolution(ScreenResolutionOption resolutionOption);
        void SetFullScreen(bool isFullScreen);
        Matrix GetScreenScaleTransformationMatrix();
    }
}