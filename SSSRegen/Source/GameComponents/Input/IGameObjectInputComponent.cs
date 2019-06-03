using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Input
{
    public interface IGameObjectInputComponent
    {
        void Initialize(IGameObject player);
        void Update(IGameObject player);
    }
}