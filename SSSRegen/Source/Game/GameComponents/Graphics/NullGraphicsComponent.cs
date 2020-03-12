using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Game.GameComponents.Graphics
{
    public class NullGraphicsComponent : IDrawableComponent<IGameObject>
    {
        public void Initialize(IGameObject entity)
        {
        }

        public void Update(IGameObject entity, IGameTime gameTime)
        {
        }

        public void Draw(IGameObject entity, IGameTime gameTime)
        {
        }
    }
}