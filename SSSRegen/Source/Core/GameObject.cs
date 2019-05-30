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
        private readonly IInputComponent _inputComponent;
        private readonly IPhysicsComponent _physicsComponent;
        private readonly IGraphicsComponent _graphicsComponent;

        public GameObject(IInputComponent inputComponent, IPhysicsComponent physicsComponent, IGraphicsComponent graphicsComponent)
        {
            _inputComponent = inputComponent ?? throw new ArgumentNullException(nameof(inputComponent));
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            _graphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));
        }

        public Vector2 Position { get; set; }
        public float HorizontalVelocity { get; set; }
        public float VerticalVelocity { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        public virtual void Initialize()
        {
            _inputComponent.Initialize(this);
            _physicsComponent.Initialize(this);
            _graphicsComponent.Initialize(this);
        }

        public virtual void Update()
        {
            _inputComponent.Update(this);
            _physicsComponent.Update(this);
            _graphicsComponent.Update(this);
        }

        public virtual void Draw(GameTime gameTime)
        {
            _graphicsComponent.Draw(this);
        }
    }
}