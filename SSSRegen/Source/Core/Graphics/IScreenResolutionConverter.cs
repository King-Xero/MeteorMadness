using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Graphics
{
    public interface IScreenResolutionConverter
    {
        Vector2 Convert(ScreenResolutionOption resolutionOption);
    }
}