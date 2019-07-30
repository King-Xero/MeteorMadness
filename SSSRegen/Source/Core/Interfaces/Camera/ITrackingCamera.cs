using SSSRegen.Source.Core.Interfaces.Entities;

namespace SSSRegen.Source.Core.Interfaces.Camera
{
    public interface ITrackingCamera : ICamera
    {
        void Follow(IGameObject target);
    }
}