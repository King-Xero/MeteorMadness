using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Camera;

namespace SSSRegen.Source.Core.Camera
{
    public abstract class Camera2D : ICamera
    {
        private float _zoom;
        private float _rotation;
        
        public float Zoom
        {
            get => _zoom;
            set
            {
                _zoom = value;
                if (_zoom < 0.1f)
                {
                    _zoom = 0.1f;
                }
            }

        }

        public float Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }

        public abstract Matrix Transform { get; }
    }
}