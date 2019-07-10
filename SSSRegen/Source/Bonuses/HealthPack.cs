using System;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Bonuses
{
    public class HealthPack : GameObject, IHandleCollisions
    {
        public HealthPack(IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) :
            base(physicsComponent, graphicsComponent)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(IGameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void CollidedWith(IHandleCollisions gameObject)
        {
            Console.WriteLine($"{GetType()} collided with {gameObject.GetType()}");

            //ToDo Assign and use collision layers
            if (gameObject is Player.Player)
            {
                IsActive = false;
            }
        }
    }
}