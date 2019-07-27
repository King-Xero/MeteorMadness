using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Graphics;

namespace SSSRegen.Source.Core.Interfaces.Graphics
{
    public interface IGameGraphics
    {
        Rectangle ScreenBounds { get; }
        ITrackingCamera PlayableCamera { get; }

        void SetResolution(ScreenResolutionOption resolutionOption);
        void SetFullScreen(bool isFullScreen);
        
        void Draw(ISprite sprite, Rectangle destinationRect, Color color);
        void Draw(ISprite sprite, Vector2 position, Color color);
        void DrawText(IUIText uiText, Vector2 position, Color color);

        void DrawPlayable(ISprite sprite, Rectangle destinationRect, Color color);
        void DrawPlayable(ISprite sprite, Vector2 position, Color color);
        void DrawTextPlayable(IUIText uiText, Vector2 position, Color color);
    }
}