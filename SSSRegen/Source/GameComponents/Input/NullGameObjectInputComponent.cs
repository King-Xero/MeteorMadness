using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Input
{
    public class NullGameObjectInputComponent : IComponent<IGameObject>
    {
        public void Initialize(IGameObject player)
        {
        }

        public void Update(IGameObject player, IGameTime gameTime)
        {
        }
    }
}