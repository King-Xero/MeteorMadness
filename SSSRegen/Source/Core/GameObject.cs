using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;

namespace SSSRegen.Source.Core
{
    public class GameObject : IGameObject
    {
        private readonly IInputComponent<IGameObject> _inputComponent;
        private readonly IPhysicsComponent _physicsComponent;
        private readonly IGraphicsComponent<IGameObject> _graphicsComponent;

        public GameObject(IInputComponent<IGameObject> inputComponent, IPhysicsComponent physicsComponent, IGraphicsComponent<IGameObject> graphicsComponent)
        {
            _inputComponent = inputComponent ?? throw new ArgumentNullException(nameof(inputComponent));
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            _graphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));
        }

        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Size { get; set; }

        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, (int) Size.X, (int) Size.Y);

        public virtual void Initialize()
        {
            _inputComponent.Initialize(this);
            _graphicsComponent.Initialize(this);
            _physicsComponent.Initialize(this);
        }

        public virtual void Update(GameTime gameTime)
        {
            _inputComponent.Update(this);
            _graphicsComponent.Update(this);
            _physicsComponent.Update(this, gameTime);
        }

        public virtual void Draw(GameTime gameTime)
        {
            _graphicsComponent.Draw(this);
        }
    }
}