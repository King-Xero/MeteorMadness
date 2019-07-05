using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;

namespace SSSRegen.Source.Projectiles
{
    public class Bullet : GameObject, IProjectile
    {
        public Bullet(IComponent<IGameObject> inputComponent, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) : base(inputComponent, physicsComponent, graphicsComponent)
        {
        }

        public bool IsActive { get; set; }
    }
}