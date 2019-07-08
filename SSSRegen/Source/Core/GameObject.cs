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
        private readonly IComponent<IGameObject> _inputComponent;
        private readonly IComponent<IGameObject> _physicsComponent;
        private readonly IDrawableComponent<IGameObject> _graphicsComponent;

        public GameObject(IComponent<IGameObject> inputComponent, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent)
        {
            _inputComponent = inputComponent ?? throw new ArgumentNullException(nameof(inputComponent));
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            _graphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));
        }

        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public Vector2 MovementDirection { get; set; }
        public Vector2 Size { get; set; }

        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, (int) Size.X, (int) Size.Y);

        public virtual void Initialize()
        {
            _inputComponent.Initialize(this);
            _graphicsComponent.Initialize(this);
            _physicsComponent.Initialize(this);
        }

        public virtual void Update(IGameTime gameTime)
        {
            _inputComponent.Update(this, gameTime);
            _graphicsComponent.Update(this, gameTime);
            _physicsComponent.Update(this, gameTime);
        }

        public virtual void Draw(IGameTime gameTime)
        {
            _graphicsComponent.Draw(this, gameTime);
        }
    }
}