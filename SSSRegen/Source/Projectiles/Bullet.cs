using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Projectiles
{
    public class Bullet : GameObject
    {
        public Bullet(IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) : base(physicsComponent, graphicsComponent)
        {
        }
    }
}