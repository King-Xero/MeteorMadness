using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Physics
{
    public interface IPhysicsComponent
    {
        void Initialize(IGameObject obj);
        void Update(IGameObject obj, GameTime gameTime);
    }
}