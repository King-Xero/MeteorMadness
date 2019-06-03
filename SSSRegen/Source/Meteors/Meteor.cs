using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;

namespace SSSRegen.Source.Meteors
{
    public class Meteor : GameObject
    {
        public Meteor(IGameObjectInputComponent inputComponent, IPhysicsComponent physicsComponent, IGraphicsComponent graphicsComponent) :
            base(inputComponent, physicsComponent, graphicsComponent)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}