using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Core.Interfaces.Graphics
{
    public interface IAnimatedSprite : ISprite
    {
        void Update(IGameTime gameTime);
    }
}