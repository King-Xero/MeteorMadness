using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IResolution
    {
        Vector2 VirtualResolution { get; }
        Vector2 ActualResolution { get; }

        void SetActualResolution(Vector2 actualResolution);
        Matrix GetTransformationMatrix();
    }
}