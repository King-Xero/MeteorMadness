using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Input
{
    public interface IInputComponent
    {
        void Initialize(IGameObject player);
        void Update(IGameObject player);
    }
}