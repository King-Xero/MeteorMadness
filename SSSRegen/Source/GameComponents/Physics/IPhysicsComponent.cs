using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Physics
{
    public interface IPhysicsComponent
    {
        void Initialize(IGameObject player);
        void Update(IGameObject player);
    }
}