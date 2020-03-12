using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces.Camera
{
    public interface IMovableCamera : ICamera
    {
        void Move(Vector2 delta);
    }
}