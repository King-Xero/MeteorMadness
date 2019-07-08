using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Bonuses
{
    public class HealthPack : GameObject
    {
        public HealthPack(IComponent<IGameObject> inputComponent, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) :
            base(inputComponent, physicsComponent, graphicsComponent)
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
    }
}