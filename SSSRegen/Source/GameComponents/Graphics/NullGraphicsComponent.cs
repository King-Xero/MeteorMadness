using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Graphics
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