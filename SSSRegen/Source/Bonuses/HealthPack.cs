using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Bonuses
{
    public class HealthPack : GameObject
    {
        public HealthPack(IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) :
            base(physicsComponent, graphicsComponent)
        {
        }

        public override void Initialize()
        {
            IsActive = true;

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
    }
}