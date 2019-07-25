using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface ICamera
    {
        float Zoom { get; set; }
        float Rotation { get; set; }
        Matrix Transform { get; }
    }

    public interface IMovableCamera : ICamera
    {
        void Move(Vector2 delta);
    }

    public interface ITrackingCamera : ICamera
    {
        void Follow(IGameObject target);
    }
}