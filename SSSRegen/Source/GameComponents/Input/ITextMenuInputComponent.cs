using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Input
{
    public interface ITextMenuInputComponent
    {
        void Initialize(ITextMenu textMenu);
        void Update(ITextMenu textMenu);
    }
}