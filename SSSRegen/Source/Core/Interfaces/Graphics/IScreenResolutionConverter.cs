using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Graphics;

namespace SSSRegen.Source.Core.Interfaces.Graphics
{
    public interface IScreenResolutionConverter
    {
        Vector2 Convert(ScreenResolutionOption resolutionOption);
    }
}