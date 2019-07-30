using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Game.GameComponents.Physics
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