using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Input
{
    public interface IInputComponent<T>
    {
        void Initialize(T textMenu);
        void Update(T textMenu);
    }
}