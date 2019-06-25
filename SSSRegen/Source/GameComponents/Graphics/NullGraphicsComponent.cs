using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public class NullGraphicsComponent : IGraphicsComponent<IGameObject>
    {
        public void Initialize(IGameObject entity)
        {
        }

        public void Update(IGameObject entity)
        {
        }

        public void Draw(IGameObject entity)
        {
        }
    }
}