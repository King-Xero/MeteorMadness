using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces.Camera
{
    public interface ICamera
    {
        float Zoom { get; set; }
        float Rotation { get; set; }
        Matrix Transform { get; }
    }
}