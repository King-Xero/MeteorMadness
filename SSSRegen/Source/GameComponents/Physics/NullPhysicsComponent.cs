using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class NullPhysicsComponent : IComponent<IGameObject>
    {
        public void Initialize(IGameObject player)
        {
        }

        public void Update(IGameObject player, IGameTime gameTime)
        {
        }
    }
}