using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class GameScreenResolution : IResolution
    {
        public GameScreenResolution(Vector2 virtualResolution, Vector2 actualResolution)
        {
            VirtualResolution = virtualResolution;
            ActualResolution = actualResolution;
        }

        public Vector2 VirtualResolution { get; private set; }

        public Vector2 ActualResolution { get; private set; }

        public void SetActualResolution(Vector2 actualResolution)
        {
            ActualResolution = actualResolution;
        }

        public Matrix GetTransformationMatrix()
        {
            var scaleX = ActualResolution.X / VirtualResolution.X;
            var scaleY = ActualResolution.Y / VirtualResolution.Y;

            return Matrix.CreateScale(scaleX, scaleY, 1.0f);
        }
    }
}