using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public interface IGraphicsComponent
    {
        void Initialize(IGameObject player);
        void Update(IGameObject player);
        void Draw(IGameObject player);
    }
}