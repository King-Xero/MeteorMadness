using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public abstract class GameObject : IGameObject
    {
        public virtual bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public Vector2 MovementDirection { get; set; }
        public Vector2 Size { get; set; }

        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, (int) Size.X, (int) Size.Y);

        public abstract void Initialize();

        public abstract void Update(IGameTime gameTime);

        public abstract void Draw(IGameTime gameTime);
    }
}