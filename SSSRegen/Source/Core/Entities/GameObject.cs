using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Core.Entities
{
    public abstract class GameObject : IGameObject
    {
        public virtual bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public float MovementSpeed { get; set; }
        public float RotationSpeed { get; set; }
        public Vector2 MovementDirection { get; set; }
        public Vector2 Size { get; set; }

        //ToDo Remove offset from draw call
        //Position.X - Origin.X, Position.Y - Origin.Y
        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, (int) Size.X, (int) Size.Y);

        public abstract void Initialize();

        public abstract void Update(IGameTime gameTime);

        public abstract void Draw(IGameTime gameTime);
    }
}