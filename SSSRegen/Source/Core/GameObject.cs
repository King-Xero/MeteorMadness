using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class GameObject : IGameObject
    {
        private readonly IComponent<IGameObject> _physicsComponent;
        private readonly IDrawableComponent<IGameObject> _graphicsComponent;

        public GameObject(IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent)
        {
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            _graphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));
        }

        public bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public Vector2 MovementDirection { get; set; }
        public Vector2 Size { get; set; }

        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, (int) Size.X, (int) Size.Y);

        public virtual void Initialize()
        {
            _graphicsComponent.Initialize(this);
            _physicsComponent.Initialize(this);
        }

        public virtual void Update(IGameTime gameTime)
        {
            _graphicsComponent.Update(this, gameTime);
            _physicsComponent.Update(this, gameTime);
        }

        public virtual void Draw(IGameTime gameTime)
        {
            _graphicsComponent.Draw(this, gameTime);
        }
    }
}