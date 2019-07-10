using System;
using SSSRegen.Source.Collision;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Projectiles
{
    public class Bullet : GameObject, IHandleCollisions
    {
        public Bullet(IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) : base(physicsComponent, graphicsComponent)
        {
        }


        public CollisionLayer CollisionLayer => CollisionLayer.Player;

        public void CollidedWith(IHandleCollisions gameObject)
        {
            Console.WriteLine($"{GetType()} collided with {gameObject.GetType()}");
            IsActive = false;
        }
    }
}